using Lasm.Dependencies.Humility;

namespace Lasm.Dependencies.CSharp
{
    public abstract class CodeGenerator<T> : Decorator<CodeGenerator<T>, CodeGenAttribute, T>
    {
        public abstract string Generate(int indent);
    }
}