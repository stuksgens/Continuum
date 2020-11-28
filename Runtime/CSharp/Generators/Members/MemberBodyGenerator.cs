using System;

namespace Lasm.Continuum.CSharp
{
    public abstract class MemberBodyGenerator : BodyGenerator
    {
        public string name;
        public AccessModifier scope;
        public Type returnType;
    }
}
