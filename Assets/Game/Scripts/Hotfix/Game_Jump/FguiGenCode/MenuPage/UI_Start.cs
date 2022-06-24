/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MenuPage
{
    public partial class UI_Start : GButton
    {
        public Controller m_button;
        public GImage m_n0;
        public const string URL = "ui://ko1119iftok05";

        public static UI_Start CreateInstance()
        {
            return (UI_Start)UIPackage.CreateObject("MenuPage", "Start");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_button = GetController("button");
            m_n0 = (GImage)GetChild("n0");
        }
    }
}