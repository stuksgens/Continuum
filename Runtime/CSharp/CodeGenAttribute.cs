using Lasm.Dependencies.Humility;
using System;

namespace Lasm.Dependencies.CSharp
{
    public sealed class CodeGenAttribute : DecoratorAttribute
    {
        public CodeGenAttribute(Type type) : base(type)
        {
        }
    }
}