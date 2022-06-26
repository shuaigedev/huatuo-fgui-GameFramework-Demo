using GameFramework.Event;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Game.Hotfix
{
    public class MainPage : FGuiForm
    {
        private ProcedureMain m_ProcedureMain;
        
        private FairyGUI.GTextField m_Grade;
        
        private int m_Score;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            m_Grade = UI.GetChild("n1").asTextField;
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            m_ProcedureMain = (ProcedureMain) userData;
            if (m_ProcedureMain == null)
            {
                Log.Error("UserData is valid");
                return;
            }

            m_Score = 0;
            
            GameEntry.Event.Subscribe(UpScoreEventArgs.EventId,OnUpScore);
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);
            GameEntry.Event.Unsubscribe(UpScoreEventArgs.EventId,OnUpScore);
        }

        private void OnUpScore(object sender, GameEventArgs e)
        {
            UpScoreEventArgs result = (UpScoreEventArgs) e;
            m_Score += result.Score;
            GameHotfixEntry.Ground.SetLevel(m_Score);
            m_Grade.text =m_Score.ToString();
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
        }
    }
}