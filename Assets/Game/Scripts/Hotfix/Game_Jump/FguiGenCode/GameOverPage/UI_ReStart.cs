/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameOverPage
{
    public partial class UI_ReStart : GButton
    {
        public Controller m_button;
        public GImage m_n0;
        public const string URL = "ui://5n6af2udnymm2";

        public static UI_ReStart CreateInstance()
        {
            return (UI_ReStart)UIPackage.CreateObject("GameOverPage", "ReStart");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_button = GetController("button");
            m_n0 = (GImage)GetChild("n0");
        }
    }
}