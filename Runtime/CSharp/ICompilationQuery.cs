using System.Collections.Generic;

namespace Lasm.Dependencies.CSharp
{
    public interface ICompilationQuery
    {
        IEnumerable<ICompilable> Query();
    }
}