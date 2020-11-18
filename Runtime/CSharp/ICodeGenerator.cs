namespace Lasm.Dependencies.CSharp
{
    public interface ICodeGenerator
    {
        string Generate(int indent);
        string GenerateClean(int indent);
    }
}