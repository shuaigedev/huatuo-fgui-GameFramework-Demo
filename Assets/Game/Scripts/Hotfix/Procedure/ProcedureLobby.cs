using System;
using System.Collections.Generic;
using GameFramework.Event;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace Game.Hotfix
{
    public class ProcedureLobby : ProcedureBase
    {
        private const float GameOverDelayedSeconds = 2f;

        private readonly Dictionary<GameMode, GameBase> m_Games = new Dictionary<GameMode, GameBase>();

        private GameBase m_CurrentGame = null;

        private bool m_GotoMenu = false;

        private float m_GotoMenuDelaySeconds = 0f;
        public GameBase CurrentGame
        {
            get { return m_CurrentGame; }
            set { m_CurrentGame = value; }
        }


        public void GotoMenu()
        {
            m_GotoMenu = true;
        }

        protected override void OnInit(ProcedureOwner procedureOwner)
        {
            base.OnInit(procedureOwner);
            m_Games.Add(GameMode.Survival, new LobbyGame());

        }

        protected override void OnDestroy(ProcedureOwner procedureOwner)
        {
            base.OnDestroy(procedureOwner);
            m_Games.Clear();
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            m_GotoMenu = false;
            GameMode gameMode = (GameMode)procedureOwner.GetData<VarByte>(Constant.ProcedureData.GameMode).Value;
            m_CurrentGame = m_Games[gameMode];
            m_CurrentGame.Initialize();
            //打开大厅界面

            if (GameEntry.UI.HasUIForm(UIFormId.LobbyPage))
            {
                GameEntry.UI.GetUIForm(UIFormId.LobbyPage).Visible = true;
            }
            else
            {
                GameEntry.UI.OpenUIForm(UIFormId.LobbyPage, this);
            }
            GameEntry.Event.Subscribe(NextGameEventArgs.EventId, OnNextGame);

        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            if (m_CurrentGame != null)
            {
                m_CurrentGame.Shutdown();
                m_CurrentGame = null;
            }

            base.OnLeave(procedureOwner, isShutdown);

            GameEntry.Event.Unsubscribe(NextGameEventArgs.EventId, OnNextGame);

        }

        private void OnNextGame(object sender, GameEventArgs e)
        {
            NextGameEventArgs args = (NextGameEventArgs)e;
            m_CurrentGame.NextGame = args.NextGameId;
            ////游戏结束
            //GameEntry.UI.OpenUIForm(UIFormId.GameOverPage, this);
        }



        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (m_CurrentGame != null)
            {
                if (m_CurrentGame.NextGame>0)
                {
                    if (m_CurrentGame.NextGame == 1)
                    {
                        ChangeState<ProcedureMain>(procedureOwner);
                    }
                }
                else
                {
                    m_CurrentGame.Update(elapseSeconds, realElapseSeconds);
                    return;
                }
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
