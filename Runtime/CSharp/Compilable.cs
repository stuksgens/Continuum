namespace Lasm.Dependencies.CSharp
{
    public struct Compilable
    {
        public string path;
        public string fileName;
        public ICodeGenerator generator;
    }
}