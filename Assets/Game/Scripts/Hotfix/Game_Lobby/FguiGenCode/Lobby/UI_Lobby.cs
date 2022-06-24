/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Lobby
{
    public partial class UI_Lobby : GComponent
    {
        public GLoader m_bg;
        public GComponent m_comp_userInfo;
        public GComponent m_comp_myGame;
        public UI_CompDicePop m_comp_dicePop;
        public UI_CompMenu m_comp_menu;
        public GComponent m_comp_dialog;
        public GLoader m_sider;
        public const string URL = "ui://mvkio9wfk9bf0";

        public static UI_Lobby CreateInstance()
        {
            return (UI_Lobby)UIPackage.CreateObject("Lobby", "Lobby");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_bg = (GLoader)GetChildAt(0);
            m_comp_userInfo = (GComponent)GetChildAt(1);
            m_comp_myGame = (GComponent)GetChildAt(2);
            m_comp_dicePop = (UI_CompDicePop)GetChildAt(3);
            m_comp_menu = (UI_CompMenu)GetChildAt(4);
            m_comp_dialog = (GComponent)GetChildAt(5);
            m_sider = (GLoader)GetChildAt(6);
        }
    }
}