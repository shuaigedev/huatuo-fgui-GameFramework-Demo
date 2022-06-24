/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MenuPage
{
    public partial class UI_Main : GComponent
    {
        public UI_Start m_n1;
        public GImage m_n2;
        public const string URL = "ui://ko1119iftok02";

        public static UI_Main CreateInstance()
        {
            return (UI_Main)UIPackage.CreateObject("MenuPage", "Main");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_n1 = (UI_Start)GetChild("n1");
            m_n2 = (GImage)GetChild("n2");
        }
    }
}