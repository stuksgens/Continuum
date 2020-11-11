using System;

namespace Lasm.Humility
{
    public sealed class CodeGenAttribute : DecoratorAttribute
    {
        public CodeGenAttribute(Type type) : base(type)
        {
        }
    }
}