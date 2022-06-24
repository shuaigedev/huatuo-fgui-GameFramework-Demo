//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2019 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using UnityEngine;

namespace Game
{
    /// <summary>
    /// 游戏入口。
    /// </summary>
    public partial class GameEntry : MonoBehaviour
    {
        /// <summary>
        /// FGUI管理
        /// </summary>
        public static FGuiComponent FGUI
        {
            get;
            private set;
        }
        /// <summary>
        /// Camera管理
        /// </summary>
        public static HotComponent HotCom
        {
            get;
            private set;
        }
        

        private static void InitCustomComponents()
        {
            FGUI = UnityGameFramework.Runtime.GameEntry.GetComponent<FGuiComponent>();
            HotCom = UnityGameFramework.Runtime.GameEntry.GetComponent<HotComponent>();
        }
    }
}
