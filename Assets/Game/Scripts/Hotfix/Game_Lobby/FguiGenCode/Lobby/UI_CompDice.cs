/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Lobby
{
    public partial class UI_CompDice : GComponent
    {
        public Controller m_UIType;
        public const string URL = "ui://mvkio9wfx20g1d";

        public static UI_CompDice CreateInstance()
        {
            return (UI_CompDice)UIPackage.CreateObject("Lobby", "CompDice");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_UIType = GetControllerAt(0);
        }
    }
}