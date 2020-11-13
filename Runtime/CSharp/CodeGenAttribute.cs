using Lasm.Dependencies.Humility;
using System;

namespace Lasm.Dependencies.CSharp
{
    public sealed class CodeGeneratorAttribute : DecoratorAttribute
    {
        public CodeGeneratorAttribute(Type type) : base(type)
        {
        }
    }
}