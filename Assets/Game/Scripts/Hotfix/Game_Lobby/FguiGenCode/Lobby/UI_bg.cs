/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Lobby
{
    public partial class UI_bg : GComponent
    {
        public GComponent m_nodes;
        public GImage m_Player;
        public const string URL = "ui://mvkio9wfx20g1h";

        public static UI_bg CreateInstance()
        {
            return (UI_bg)UIPackage.CreateObject("Lobby", "bg");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_nodes = (GComponent)GetChildAt(1);
            m_Player = (GImage)GetChildAt(2);
        }
    }
}