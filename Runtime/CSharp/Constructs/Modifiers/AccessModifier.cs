﻿using System;
using System.Reflection;

namespace Lasm.CSharp
{ 
    /// <summary>
    /// The scope of a C# construct. Excludes root constructs, such as a class declaration. Use RootAccessModifier for those.
    /// </summary>
    public enum AccessModifier
    {
        Public,
        Private,
        Protected,
        Internal,
        ProtectedInternal,
        PrivateProtected
    }
}