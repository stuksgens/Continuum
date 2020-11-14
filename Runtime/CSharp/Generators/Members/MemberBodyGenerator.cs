using System;

namespace Lasm.Dependencies.CSharp
{
    public abstract class MemberBodyGenerator : BodyGenerator
    {
        public string name;
        public AccessModifier scope;
        public Type returnType;
    }
}
