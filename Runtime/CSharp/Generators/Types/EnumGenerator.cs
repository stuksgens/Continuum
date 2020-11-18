﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lasm.Dependencies.CSharp
{
    public sealed class EnumGenerator : TypeGenerator
    {
#pragma warning disable 0649
        private RootAccessModifier scope;
#pragma warning restore 0649
        private string typeName;
        private List<AttributeGenerator> attributes = new List<AttributeGenerator>();
        private List<EnumValueGenerator> items = new List<EnumValueGenerator>();
        public bool indexing;

        protected override string GenerateBefore(int indent)
        {
            var output = string.Empty;

            for (int i = 0; i < attributes.Count; i++)
            {
                output += attributes[i].Generate(indent) + "\n";
            }

            output += CodeBuilder.Indent(indent) + scope.AsString().ConstructHighlight() + " enum ".ConstructHighlight() + typeName.LegalMemberName().EnumHighlight();

            return output;
        }

        protected override string GenerateBody(int indent)
        {
            var output = string.Empty;
            
            for (int i = 0; i < items.Count; i++)
            {
                if (string.IsNullOrEmpty(items[i].name)) { continue; }
                output += CodeBuilder.Indent(indent) + items[i].name.LegalMemberName() + (indexing ? " = " + items[i].index.ToString().NumericHighlight() : string.Empty);
                if (i < items.Count - 1)
                {
                    output += ",";
                    output += "\n";
                }
            }

            return output;
        }

        protected override string GenerateAfter(int indent)
        {
            return string.Empty;
        }

        private EnumGenerator(string name) { this.typeName = name; }

        public static EnumGenerator Enum(string name)
        {
            return new EnumGenerator(name);
        }

        public EnumGenerator AddItem(string itemName, int index)
        {
            var enumValue = new EnumValueGenerator();
            enumValue.name = itemName;
            enumValue.index = index;
            items.Add(enumValue);
            return this;
        }

        public EnumGenerator AddAttribute(AttributeGenerator generator)
        {
            attributes.Add(generator);
            return this;
        }
    }
}