using System.Collections;

namespace Lasm.EbbnFlow
{
    public interface IFunction
    {
        bool isCoroutine { get; }

        object Invoke(Flow flow);

        IEnumerator Run(Flow flow);
    }

    public interface IFunction<T>
    {
        T Invoke(Flow flow);
    }
}