/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Lobby
{
    public partial class UI_CompDicePop : GComponent
    {
        public UI_CompDice m_comp_dice;
        public GButton m_btn_confirm;
        public const string URL = "ui://mvkio9wfx20g15";

        public static UI_CompDicePop CreateInstance()
        {
            return (UI_CompDicePop)UIPackage.CreateObject("Lobby", "CompDicePop");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_comp_dice = (UI_CompDice)GetChildAt(3);
            m_btn_confirm = (GButton)GetChildAt(4);
        }
    }
}