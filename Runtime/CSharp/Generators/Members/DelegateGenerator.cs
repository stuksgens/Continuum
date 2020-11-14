using System;
using System.Collections.Generic;

namespace Lasm.Dependencies.CSharp
{
    public sealed class DelegateGenerator : MemberGenerator
    {
        private List<ParameterGenerator> parameters = new List<ParameterGenerator>();
        private object defaultValue;

        private DelegateGenerator() { }

        public static DelegateGenerator Event(AccessModifier scope, Type returnType, string name)
        {
            return new DelegateGenerator()
            {
                scope = scope,
                returnType = returnType,
                name = name
            };
        }

        public DelegateGenerator AddParameter(ParameterGenerator generator)
        {
            parameters.Add(generator);
            return this;
        }

        public override string Generate(int indent)
        {
            return CodeBuilder.Indent(indent) + scope.AsString() + " delegate ".ConstructHighlight() + returnType.Name + " " + name + "(" + GenerateParameters() + ");";

            string GenerateParameters()
            {
                var output = string.Empty;
                for (int i = 0; i < parameters.Count; i++)
                {
                    output += parameters[i].Generate(0);
                    output += i < parameters.Count - 1 ? ", " : string.Empty;
                }
                return output;
            }
        }
    }
}
