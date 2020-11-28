using Lasm.Continuum.Humility;
using System;
using System.Collections.Generic;

namespace Lasm.Continuum.CSharp
{
    public sealed class FieldGenerator : ConstructGenerator
    {
        public AccessModifier scope;
        public FieldModifier modifier;
        public string name;
        public object defaultValue;
        public bool isString;
        public string stringDefault;
        public Type type;
        public List<AttributeGenerator> attributes = new List<AttributeGenerator>();

        private FieldGenerator() { }

        public static FieldGenerator Field(AccessModifier scope, FieldModifier modifier, Type type, string name)
        {
            var field = new FieldGenerator();
            field.scope = scope;
            field.modifier = modifier;
            field.type = type;
            field.name = name;
            field.defaultValue = HUMValue.Create().New(type);
            return field;
        }

        public FieldGenerator Default(object value)
        {
            defaultValue = value;
            isString = false;
            return this;
        }

        public FieldGenerator CustomDefault(string value)
        {
            isString = true;
            stringDefault = value;
            return this;
        }

        public FieldGenerator AddAttribute(AttributeGenerator attributeGenerator)
        {
            attributes.Add(attributeGenerator);
            return this;
        }

        public override string Generate(int indent)
        {
            if (string.IsNullOrEmpty(name)) { return string.Empty; }

            var _attributes = string.Empty;
            var count = 0;

            foreach (AttributeGenerator attr in attributes)
            {
                _attributes += attr.Generate(indent) + ((count < attributes.Count - 1) ? "\n" : string.Empty);
            }

            var modSpace = (modifier == FieldModifier.None) ? string.Empty : " ";
            var definition = CodeBuilder.Indent(indent) + scope.AsString().ConstructHighlight() + " " + modifier.AsString().ConstructHighlight() + modSpace + type.As().CSharpName() + " " + name.LegalMemberName();
            var output = !isString && (defaultValue == null || defaultValue.Equals(HUMValue.Create().New(type))) ? ";" : " = " + (isString ? stringDefault : defaultValue.As().Code(true) + ";");
            return _attributes + definition + output;
        }

        public List<string> Usings()
        {
            var usings = new List<string>();

            if (type != typeof(void)) usings.Add(type.Namespace);

            for (int i = 0; i < attributes.Count; i++)
            {
                usings.MergeUnique(attributes[i].Usings());
            }

            return usings;
        }
    }
}