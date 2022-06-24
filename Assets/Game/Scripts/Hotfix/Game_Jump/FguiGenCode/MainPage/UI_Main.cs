/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainPage
{
    public partial class UI_Main : GComponent
    {
        public GTextField m_n1;
        public GImage m_n4;
        public const string URL = "ui://46teulsdtok00";

        public static UI_Main CreateInstance()
        {
            return (UI_Main)UIPackage.CreateObject("MainPage", "Main");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_n1 = (GTextField)GetChild("n1");
            m_n4 = (GImage)GetChild("n4");
        }
    }
}