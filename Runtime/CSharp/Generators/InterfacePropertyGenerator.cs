using Lasm.Humility;
using System;

namespace Lasm.CSharp
{
    public sealed class InterfacePropertyGenerator : ConstructGenerator
    {
        public string name;
        public Type type;
        public string get;
        public string set;

        public override string Generate(int indent)
        {
            return type.As().CSharpName() + " " + name.LegalMemberName() + " " + "{ " + get + " " + set + "}";
        }

        private InterfacePropertyGenerator() { }

        public static InterfacePropertyGenerator Property(string name, Type type, bool get, bool set)
        {
            var interfaceProp = new InterfacePropertyGenerator();
            interfaceProp.name = name;
            interfaceProp.type = type;
            interfaceProp.get = (get ? "get".ConstructHighlight() + "; " : string.Empty);
            interfaceProp.set = (set ? "set".ConstructHighlight() + "; " : string.Empty);
            return interfaceProp;
        }
    }
}