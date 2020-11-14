namespace Lasm.Dependencies.CSharp
{
    public abstract class ConstructGenerator
    {
        public abstract string Generate(int indent);

        public string GenerateWithoutStyles(int indent)
        {
            var output = this.Generate(indent);
            return output.RemoveHighlights().RemoveMarkdown();
        }
    }
}