/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Lobby
{
    public partial class UI_CompMenu : GComponent
    {
        public GGraph m_bg;
        public GButton m_btn_wallet;
        public GButton m_btn_roleicon;
        public GButton m_btn_market;
        public GButton m_btn_search;
        public GButton m_btn_safety;
        public const string URL = "ui://mvkio9wfx20g16";

        public static UI_CompMenu CreateInstance()
        {
            return (UI_CompMenu)UIPackage.CreateObject("Lobby", "CompMenu");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_bg = (GGraph)GetChildAt(0);
            m_btn_wallet = (GButton)GetChildAt(1);
            m_btn_roleicon = (GButton)GetChildAt(2);
            m_btn_market = (GButton)GetChildAt(3);
            m_btn_search = (GButton)GetChildAt(4);
            m_btn_safety = (GButton)GetChildAt(5);
        }
    }
}