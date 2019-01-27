using UnityEngine;

namespace Alexplay.Balda.App
{
    public class ViewUtils
    {
        private const float BaseScreenRatio = 9f / 16f;
        private const float BaseScreenHalfHeight = 10f;  //9.6f
        private const float BaseScreenHeight = BaseScreenHalfHeight * 2;

        public static float ScreenRatio = (float) Screen.width / Screen.height;

        public static float ScreenHalfHeight = BaseScreenHalfHeight * Mathf.Max(BaseScreenRatio / ScreenRatio, 1f);
        public static float ScreenHeight = ScreenHalfHeight * 2;

        public static float ScreenHalfWidth = ScreenHalfHeight * ScreenRatio;
        public static float ScreenWidth = ScreenHalfWidth * 2;
    }
}