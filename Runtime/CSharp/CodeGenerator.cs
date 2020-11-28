using Lasm.Continuum.Humility;

namespace Lasm.Continuum.CSharp
{
    public abstract class CodeGenerator<T> : Decorator<CodeGenerator<T>, CodeGeneratorAttribute, T>, ICodeGenerator
    {
        public abstract string Generate(int indent);

        public string GenerateClean(int indent)
        {
            return Generate(indent).RemoveHighlights().RemoveMarkdown();
        }
    }
}