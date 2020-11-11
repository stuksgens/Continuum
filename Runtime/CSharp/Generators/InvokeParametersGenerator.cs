﻿using Lasm.Dependencies.Humility;
using System.Collections.Generic;

namespace Lasm.Dependencies.CSharp
{
    public sealed class InvokeParametersGenerator : ConstructGenerator
    {
        private List<ParameterGenerator> parameters = new List<ParameterGenerator>();
        public int Count => parameters.Count;

        public override string Generate(int indent)
        {
            var output = string.Empty;
            
            for (int i = 0; i < parameters.Count; i++)
            {
                output += parameters[i].As().Code(true);
                if (i < Count - 1) output += ", ";
            }

            return "(" + output + ")";
        }

        private InvokeParametersGenerator()
        {

        }

        public static InvokeParametersGenerator InvokeParameters()
        {
            var parameters = new InvokeParametersGenerator();
            return parameters;
        }

        public InvokeParametersGenerator Parameter(ParameterGenerator parameter)
        {
            parameters.Add(parameter);
            return this;
        }

        public InvokeParametersGenerator Set(params ParameterGenerator[] parameters)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                this.parameters.Add(parameters[i]);
            }
            return this;
        }

        public List<string> Using()
        {
            var usings = new List<string>();

            for (int i = 0; i < parameters.Count; i++)
            {
                var @namespace = parameters[i]?.GetType().Namespace;

                if (!string.IsNullOrEmpty(@namespace) && !usings.Contains(@namespace))
                {
                    usings.Add(@namespace);
                }
            }
            return usings;
        }
    }
}