using Lasm.Continuum.Humility;
using System.Collections.Generic;
using UnityEditor;

namespace Lasm.Continuum.CSharp
{
    public sealed class EnumCompilationQuery : CompilationQuery
    {
        public override IEnumerable<Compilable> Query()
        {
            var enums = HUMAssets.Find().Assets().OfType<EnumAsset>();

            foreach(EnumAsset asset in enums)
            {
                var generator = EnumAssetGenerator.GetDecorator(asset);
                var fullPath = AssetDatabase.GUIDToAssetPath(asset.GetGUID());
                var path = fullPath.Replace(asset.name + ".asset", string.Empty);
                var fileName = fullPath.Replace(path, string.Empty);
                yield return new Compilable() { fileName = asset.title.LegalMemberName() + ".cs", path = path, generator = generator };
            }
        }
    }
}