using FairyGUI;

namespace Game.Hotfix
{
    public class LoginPage : FGuiForm
    {
        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            UI.GetChild("n0").onClick.Add(ToMenu);
        }

        private void ToMenu(EventContext context)
        {
            GameEntry.UI.OpenUIForm(UIFormId.MenuPage, this);
            Close();
        }
    }
}