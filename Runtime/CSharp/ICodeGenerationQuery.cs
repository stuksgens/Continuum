using System.Collections.Generic;

namespace Lasm.Dependencies.CSharp
{
    public interface ICodeGenerationQuery
    {
        IEnumerable<ICompilable> Query();
    }
}