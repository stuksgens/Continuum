﻿using Lasm.Continuum.Humility;
using System.Collections;
using UnityEngine;

namespace Lasm.Continuum.CSharp
{
    [CodeGenerator(typeof(EnumAsset))]
    public sealed class EnumAssetGenerator : CodeGenerator<EnumAsset>
    {
        private NamespaceGenerator @namespace;
        private EnumGenerator @enum;
        private string output;

        public override string Generate(int indent)
        {
            if (!(string.IsNullOrEmpty(decorated.@namespace) || string.IsNullOrWhiteSpace(decorated.@namespace))) @namespace = NamespaceGenerator.Namespace(decorated.@namespace.ToString());
            @enum = EnumGenerator.Enum(decorated.title.LegalMemberName());
            @enum.indexing = decorated.index;

            for (int i = 0; i < decorated.items.Count; i++)
            {
                @enum.AddItem(decorated.items[i].name, decorated.items[i].index);
            }

            @namespace?.AddEnum(@enum);
            output = (string.IsNullOrEmpty(decorated.@namespace) || string.IsNullOrWhiteSpace(decorated.@namespace)) ? @enum.Generate(0) : @namespace.Generate(0);

            return output;
        }
    }
}