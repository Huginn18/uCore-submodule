namespace HoodedCrow.uCore.Utils
{
    using UnityEngine;

    public static class ColorExtensions
    {
        public static Color SetAlpha(this Color color, float value)
        {
            color.a = value;
            return color;
        }
    }
}
