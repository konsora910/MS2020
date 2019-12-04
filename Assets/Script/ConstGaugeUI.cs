using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConstGaugeUI
{

    public static class ConstUI
    {
        /// <summary>
        /// フライパン調理時間
        /// </summary>
        public static float FLYINGPAN_COOKING_TIME = 5.0f;

        /// <summary>
        /// 鍋調理時間
        /// </summary>
        public static float POT_COOKING_TIME = 7.0f;

        /// <summary>
        /// フライパンのゲージ位置
        /// </summary>
        public static readonly float[] FLYINGPAN_POSITION = {
            0.0f, 1.0f, 0.0f
        };

        /// <summary>
        /// 鍋のゲージ表示位置
        /// </summary>
        public static readonly float[] POT_POSITION = {
            0.0f, 1.0f, 0.0f
        };
        

    }

}
