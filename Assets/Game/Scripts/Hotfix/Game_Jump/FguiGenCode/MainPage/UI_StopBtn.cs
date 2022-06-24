/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainPage
{
    public partial class UI_StopBtn : GButton
    {
        public Controller m_button;
        public GImage m_n0;
        public const string URL = "ui://46teulsdtok02";

        public static UI_StopBtn CreateInstance()
        {
            return (UI_StopBtn)UIPackage.CreateObject("MainPage", "StopBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_button = GetController("button");
            m_n0 = (GImage)GetChild("n0");
        }
    }
}