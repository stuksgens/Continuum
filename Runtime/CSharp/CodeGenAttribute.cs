using Lasm.Continuum.Humility;
using System;

namespace Lasm.Continuum.CSharp
{
    public sealed class CodeGeneratorAttribute : DecoratorAttribute
    {
        public CodeGeneratorAttribute(Type type) : base(type)
        {
        }
    }
}