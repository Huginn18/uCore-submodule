namespace HoodedCrow.uCore.Utils
{
    using UnityEngine;

    public static class ColorExtensions
    {
        public static Color SetRed(this Color color, float value)
        {
            color.r = value;
            return color;
        }

        public static Color SetGreen(this Color color, float value)
        {
            color.g = value;
            return color;
        }

        public static Color SetAlpha(this Color color, float value)
        {
            color.a = value;
            return color;
        }
    }
}
