using Lasm.Humility;
using System;

namespace Lasm.CSharp
{
    public sealed class CodeGenAttribute : DecoratorAttribute
    {
        public CodeGenAttribute(Type type) : base(type)
        {
        }
    }
}