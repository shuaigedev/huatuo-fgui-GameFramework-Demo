/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Lobby
{
    public partial class UI_CompGameDice : GComponent
    {
        public GImage m_saizi0;
        public GImage m_saizi1;
        public GImage m_saizi2;
        public GImage m_saizi3;
        public GImage m_saizi4;
        public GImage m_saizi5;
        public GImage m_saizi6;
        public const string URL = "ui://mvkio9wfx20g17";

        public static UI_CompGameDice CreateInstance()
        {
            return (UI_CompGameDice)UIPackage.CreateObject("Lobby", "CompGameDice");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_saizi0 = (GImage)GetChildAt(1);
            m_saizi1 = (GImage)GetChildAt(4);
            m_saizi2 = (GImage)GetChildAt(5);
            m_saizi3 = (GImage)GetChildAt(6);
            m_saizi4 = (GImage)GetChildAt(7);
            m_saizi5 = (GImage)GetChildAt(8);
            m_saizi6 = (GImage)GetChildAt(9);
        }
    }
}