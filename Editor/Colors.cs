using Lasm.Continuum.Humility;
using UnityEngine;

namespace Lasm.Continuum.Editor
{
    public static class Colors
    {
        public static Color background => HUMColor.Grey(0.14f);
        public static Color border => HUMColor.Grey(0f);
        public static Color titlebarBackground => background.Darken(0.1f);
        public static Color messageBackground => titlebarBackground;
        public static Color messageText => HUMColor.Grey(0.8f);
        public static Color whiteLabel => HUMColor.Grey(0.9f);
        public static Color field => HUMColor.Grey(0.21f);
        public static Color fieldText => HUMColor.Grey(0.65f);

        public static Color objects => new Color(0.23f, 0f, 0.49f);
        public static Color pawns => new Color(0.15f, 0.29f, 0.64f);
        public static Color properties => new Color(0.67f, 0.12f, 0.13f);
        public static Color scenes => new Color(0.08f, 0.52f, 0.05f);
    }
}
