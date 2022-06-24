using GameFramework;
using MenuPage;
using UnityGameFramework.Runtime;

namespace Game.Hotfix
{
    public class MenuPage : FGuiForm
    {
        private void Start()
        {
            Log.Info("MenuPage test---------------------");
        }
        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            UI_Main ui = UI.asCom as UI_Main;
            ui.m_n1.onClick.Add(() =>
            {
                Log.Info("MenuPage n1 click");
                GameEntry.Event.Fire(this, ReferencePool.Acquire<StartGameEventArgs>().Fill());
            });
        }
    }
}
