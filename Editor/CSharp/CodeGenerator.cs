using Lasm.Humility;

namespace Lasm.CSharp
{
    public abstract class CodeGenerator<T> : Decorator<CodeGenerator<T>, CodeGenAttribute, T>
    {
        public abstract string Generate(int indent);
    }
}