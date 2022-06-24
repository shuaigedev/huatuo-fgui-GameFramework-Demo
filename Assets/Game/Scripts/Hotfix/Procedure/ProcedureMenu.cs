using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Procedure;
using GameFramework.Resource;
using System;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Game.Hotfix
{
    public class ProcedureMenu : ProcedureBase
    {
        private bool m_StartGame = false;
        //private MenuForm m_MenuForm = null;

        public void StartGame()
        {
            m_StartGame = true;
        }

        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);

            GameEntry.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);

            m_StartGame = false;
            Log.Info("ProcedureMenu OnEnter");
            // 加载自定义组件。
           // GameEntry.Resource.LoadAsset("Assets/Game/Res/UI/UIForms/TestPage.prefab", new LoadAssetCallbacks(OnLoadAssetSuccess, OnLoadAssetFail));
            GameEntry.UI.OpenUIForm(UIFormId.MenuPage, this);
            GameEntry.Event.Subscribe(StartGameEventArgs.EventId, OnStartGame);
        }

        private void OnLoadAssetSuccess(string assetName, object asset, float duration, object userdata)
        {
            GameObject game = GameObject.Instantiate((GameObject)asset);
            game.name = "TestPage";
            //game.AddComponent<TestPage>();
        }

        private void OnLoadAssetFail(string assetName, LoadResourceStatus status, string errormessage, object userdata)
        {
            Log.Error("Load game failed. {0}", errormessage);
        }

        private void OnStartGame(object sender, GameEventArgs e)
        {
            m_StartGame = true;
        }

        protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);

            GameEntry.Event.Unsubscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);

            //if (m_MenuForm != null)
            //{
            //    m_MenuForm.Close(isShutdown);
            //    m_MenuForm = null;
            //}
        }

        protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (m_StartGame)
            {
                procedureOwner.SetData<VarInt32>("NextSceneId", GameEntry.Config.GetInt("Scene.Lobby"));
                procedureOwner.SetData<VarByte>("GameMode", (byte)GameMode.Survival);
                ChangeState<ProcedureChangeScene>(procedureOwner);
            }
        }

        private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
        {
            OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            //m_MenuForm = (MenuForm)ne.UIForm.Logic;
        }
    }
}
