/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace GameOverPage
{
    public partial class UI_Main : GComponent
    {
        public GGraph m_n5;
        public GGraph m_n0;
        public GTextField m_n1;
        public UI_ReStart m_n2;
        public UI_Home m_n4;
        public Transition m_t0;
        public const string URL = "ui://5n6af2udnymm0";

        public static UI_Main CreateInstance()
        {
            return (UI_Main)UIPackage.CreateObject("GameOverPage", "Main");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_n5 = (GGraph)GetChild("n5");
            m_n0 = (GGraph)GetChild("n0");
            m_n1 = (GTextField)GetChild("n1");
            m_n2 = (UI_ReStart)GetChild("n2");
            m_n4 = (UI_Home)GetChild("n4");
            m_t0 = GetTransition("t0");
        }
    }
}