using System.Collections.Generic;

namespace Lasm.Continuum.CSharp
{
    public abstract class CompilationQuery
    {
        public abstract IEnumerable<Compilable> Query();
    }
}