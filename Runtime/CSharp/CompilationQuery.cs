using System.Collections.Generic;

namespace Lasm.Dependencies.CSharp
{
    public abstract class CompilationQuery
    {
        public abstract IEnumerable<Compilable> Query();
    }
}