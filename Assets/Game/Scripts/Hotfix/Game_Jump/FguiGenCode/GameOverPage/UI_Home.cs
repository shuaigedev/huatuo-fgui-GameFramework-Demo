/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameOverPage
{
    public partial class UI_Home : GButton
    {
        public Controller m_button;
        public GImage m_n0;
        public const string URL = "ui://5n6af2udnymm7";

        public static UI_Home CreateInstance()
        {
            return (UI_Home)UIPackage.CreateObject("GameOverPage", "Home");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_button = GetController("button");
            m_n0 = (GImage)GetChild("n0");
        }
    }
}