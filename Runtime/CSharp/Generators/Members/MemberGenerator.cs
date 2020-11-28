using System;

namespace Lasm.Continuum.CSharp
{
    public abstract class MemberGenerator : ConstructGenerator
    {
        public string name;
        public AccessModifier scope;
        public Type returnType;
    }
}
