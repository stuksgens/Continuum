using Lasm.Humility;
using System;

namespace Lasm.CSharp
{
    public sealed class ParameterGenerator : ConstructGenerator
    {
        public string name;
        public Type type;
        public string stringType;
        public bool isLiteral;
        public ParameterModifier modifier;

        public override string Generate(int indent)
        {
            return type == null ? stringType + " " + name : type.As().CSharpName() + " " + name.LegalMemberName();
        }

        private ParameterGenerator()
        {

        }

        public static ParameterGenerator Parameter(string name, Type type, ParameterModifier modifier, bool isLiteral = false)
        {
            var parameter = new ParameterGenerator();
            parameter.name = name;
            parameter.type = type;
            parameter.modifier = modifier;
            parameter.isLiteral = isLiteral;
            return parameter;
        }

        public static ParameterGenerator Parameter(string name, string type, ParameterModifier modifier, bool isLiteral = false)
        {
            var parameter = new ParameterGenerator();
            parameter.name = name;
            parameter.stringType = type;
            parameter.modifier = modifier;
            parameter.isLiteral = isLiteral;
            return parameter;
        }

        public string Using()
        {
            return type == typeof(void) ? string.Empty : type.Namespace;
        }
    }
}