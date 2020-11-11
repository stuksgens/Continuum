﻿using Lasm.Dependencies.Humility;
using System;
using System.Collections.Generic;

namespace Lasm.Dependencies.CSharp
{
    public sealed class PropertyGenerator : ConstructGenerator
    {
#pragma warning disable 0649
        public AccessModifier scope;
        public PropertyModifier modifier;
        public AccessModifier getterScope;
        public AccessModifier setterScope;
        public bool hasGetter;
        public bool hasSetter;
        private string getterBody;
        private string setterBody;
        private bool multiStatementGetter;
        private bool multiStatementSetter;
        public string name;
        public object defaultValue;
        private bool hasDefault;
        public Type returnType;
        private string returnTypeString;
        private bool returnTypeIsString;
        private bool stringIsValueType;
        private bool stringIsPrimitive;
        private bool hasBackingField;
        public List<AttributeGenerator> attributes = new List<AttributeGenerator>();
#pragma warning restore 0649

        private PropertyGenerator() { }

        public static PropertyGenerator Property(AccessModifier scope, PropertyModifier modifier, Type returnType, string name, bool hasDefault)
        {
            var prop = new PropertyGenerator();
            prop.scope = scope;
            prop.modifier = modifier;
            prop.name = name;
            prop.returnType = returnType;
            return prop;
        }

        public static PropertyGenerator Property(AccessModifier scope, PropertyModifier modifier, string returnType, string name, bool hasDefault, bool isPrimitive, bool isValueType)
        {
            var prop = new PropertyGenerator();
            prop.scope = scope;
            prop.modifier = modifier;
            prop.name = name;
            prop.returnTypeString = returnType;
            prop.returnTypeIsString = true;
            prop.stringIsPrimitive = isPrimitive;
            prop.stringIsValueType = isValueType;
            return prop;
        }

        public PropertyGenerator Default(object value)
        {
            defaultValue = value;
            return this;
        }

        public PropertyGenerator SingleStatementGetter(AccessModifier scope, string body)
        {
            this.getterScope = scope;
            multiStatementGetter = false;
            getterBody = body;
            hasGetter = true;
            return this;
        }


        public PropertyGenerator MultiStatementGetter(AccessModifier scope, string body)
        {
            this.getterScope = scope;
            multiStatementGetter = true;
            getterBody = body;
            hasGetter = true;
            return this;
        }

        public PropertyGenerator SingleStatementSetter(AccessModifier scope, string body)
        {
            this.setterScope = scope;
            multiStatementGetter = false;
            setterBody = body;
            hasSetter = true;
            return this;
        }


        public PropertyGenerator MultiStatementSetter(AccessModifier scope, string body)
        {
            this.setterScope = scope;
            multiStatementSetter = true;
            setterBody = body;
            hasSetter = true;
            return this;
        }

        public PropertyGenerator AddAttribute(AttributeGenerator attributeGenerator)
        {
            attributes.Add(attributeGenerator);
            return this;
        }

        public override string Generate(int indent)
        {
            if (returnTypeIsString)
            {
                var _attributes = string.Empty;

                foreach (AttributeGenerator attr in attributes)
                {
                    _attributes += attr.Generate(indent) + "\n";
                }

                var modSpace = (modifier == PropertyModifier.None) ? string.Empty : " ";
                var definition = CodeBuilder.Indent(indent) + scope.AsString().ConstructHighlight() + " " + modifier.AsString().ConstructHighlight() + modSpace + returnTypeString + " " + name.LegalMemberName() + " " + GetterSetter();
                var output = defaultValue == null && returnType.IsValueType && returnType.IsPrimitive ? (hasGetter || hasSetter ? string.Empty : ";") : hasDefault ? " = " + defaultValue.As().Code(true) + ";" : string.Empty;
                return _attributes + definition + output;
            }
            else
            {
                var _attributes = string.Empty;

                foreach (AttributeGenerator attr in attributes)
                {
                    _attributes += attr.Generate(indent) + "\n";
                }

                var modSpace = (modifier == PropertyModifier.None) ? string.Empty : " ";
                var definition = CodeBuilder.Indent(indent) + scope.AsString().ConstructHighlight() + " " + modifier.AsString() + modSpace + returnType.As().CSharpName() + " " + name + " " + GetterSetter();
                var output = defaultValue == null && stringIsValueType && stringIsPrimitive ? (hasGetter || hasSetter ? string.Empty : ";") : hasDefault ? " = " + defaultValue.As().Code(true) + ";" : string.Empty;
                return _attributes + definition + output;
            }

            string GetterSetter()
            {
                var result = string.Empty;

                if (multiStatementGetter || multiStatementSetter)
                {
                    return (getterBody == null ? string.Empty : "\n" + CodeBuilder.Indent(indent) + "{\n" + Getter()) + (setterBody == null ? string.Empty : "\n" + Setter() + "\n") + "\n" + CodeBuilder.Indent(indent) + "}";
                }
                else
                {
                    return "{ " + (getterBody == null ? string.Empty : Getter() + " ") + (setterBody == null ? string.Empty : (getterBody == null ? " " : string.Empty) + Setter() + " ") + "}";
                }
            }

            string Getter()
            {
                if (multiStatementGetter)
                {
                    return CodeBuilder.Indent(indent + 1) + "get\n".ConstructHighlight() + CodeBuilder.Indent(indent + 1) +"{\n" + CodeBuilder.Indent(indent + 2) + getterBody.Replace("\n", "\n" + CodeBuilder.Indent(indent + 2)) + "\n" + CodeBuilder.Indent(indent + 1) + "}";
                }
                else
                {
                    return "get".ConstructHighlight() + " => " + getterBody.Replace("\n", "\n" + CodeBuilder.Indent(indent + 1)) + ";";
                }
            }

            string Setter()
            {
                if (multiStatementSetter)
                {
                    return CodeBuilder.Indent(indent + 1) + "set \n".ConstructHighlight() + "{\n" + setterBody.Replace("\n", "\n" + CodeBuilder.Indent(indent + 1)) + "\n}";
                }
                else
                {
                    return "set".ConstructHighlight() + " => " + setterBody.Replace("\n", "\n" + CodeBuilder.Indent(indent + 1)) + ";";
                }
            }
        }

        public List<string> Usings()
        {
            var usings = new List<string>();

            usings.Add(returnTypeIsString ? Type.GetType(returnTypeString).Namespace : returnType.Namespace);

            for (int i = 0; i < attributes.Count; i++)
            {
                usings.MergeUnique(attributes[i].Usings());
            }

            return usings;
        }
    }
}