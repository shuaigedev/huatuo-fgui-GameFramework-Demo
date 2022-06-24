using System;
using System.Collections.Generic;
using GameFramework.Event;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace Game.Hotfix
{
    public class ProcedureMain : ProcedureBase
    {
        private const float GameOverDelayedSeconds = 2f;

        private readonly Dictionary<GameMode, GameBase> m_Games = new Dictionary<GameMode, GameBase>();
        
        private GameBase m_CurrentGame = null;
        
        private float m_GotoLobbyTime = 2f;
        public GameBase CurrentGame
        {
            get { return m_CurrentGame; }
            set { m_CurrentGame = value; }
        }
        

        protected override void OnInit(ProcedureOwner procedureOwner)
        {
            base.OnInit(procedureOwner);
            m_GotoLobbyTime = 2f;
            m_Games.Add(GameMode.Survival, new SurvivalGame());
        }

        protected override void OnDestroy(ProcedureOwner procedureOwner)
        {
            base.OnDestroy(procedureOwner);
            m_Games.Clear();
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            GameMode gameMode = (GameMode)procedureOwner.GetData<VarByte>(Constant.ProcedureData.GameMode).Value;
            m_CurrentGame = m_Games[gameMode];
            m_CurrentGame.Initialize();
            //打开战斗界面
            GameEntry.UI.OpenUIForm(UIFormId.MainPage, this);
            GameEntry.Event.Subscribe(GameOverEventArgs.EventId,OnGameOver);
            
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            if (m_CurrentGame != null)
            {
                m_CurrentGame.Shutdown();
                m_CurrentGame = null;
            }

            base.OnLeave(procedureOwner, isShutdown);
            
            GameEntry.Event.Unsubscribe(GameOverEventArgs.EventId,OnGameOver);

            if (GameEntry.UI.HasUIForm(UIFormId.MainPage))
            {
                GameEntry.UI.GetUIForm(UIFormId.MainPage).Close();
            }
            if (GameEntry.UI.HasUIForm(UIFormId.GameOverPage))
            {
                GameEntry.UI.GetUIForm(UIFormId.GameOverPage).Close();
            }
        }

        private void OnGameOver(object sender, GameEventArgs e)
        {
            //游戏结束
            GameEntry.UI.OpenUIForm(UIFormId.GameOverPage, this);
            m_CurrentGame.GameOver = true;
        }



        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (m_CurrentGame != null && !m_CurrentGame.GameOver)
            {
                m_CurrentGame.Update(elapseSeconds, realElapseSeconds);
                return;
            }
            m_GotoLobbyTime -= elapseSeconds;
            if (m_GotoLobbyTime <= 0)
            {
                ChangeState<ProcedureLobby>(procedureOwner);
            }
//            if (!m_GotoMenu)
//            {
//                m_GotoMenu = true;
//                m_GotoMenuDelaySeconds = 0;
//            }
//
//            m_GotoMenuDelaySeconds += elapseSeconds;
//            if (m_GotoMenuDelaySeconds >= GameOverDelayedSeconds)
//            {
//                procedureOwner.SetData<VarInt>(Constant.ProcedureData.NextSceneId, GameEntry.Config.GetInt("Scene.Menu"));
//                ChangeState<ProcedureChangeScene>(procedureOwner);
//            }
        }
    }
}
