using Lasm.Dependencies.Humility;

namespace Lasm.Dependencies.CSharp
{
    public abstract class CodeGenerator<T> : Decorator<CodeGenerator<T>, CodeGeneratorAttribute, T>
    {
        public abstract ConstructGenerator Generate(int indent);
    }
}