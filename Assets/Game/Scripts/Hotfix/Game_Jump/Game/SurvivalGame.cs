using System.Collections.Generic;
using GameFramework;
using GameFramework.Event;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Game.Hotfix
{
    public class SurvivalGame : GameBase
    {
        public override GameMode GameMode
        {
            get { return GameMode.Survival; }
        }
        int nextGame = 0;
        public override int NextGame
        {
            get
            {
                return nextGame;
            }
            set
            {
                nextGame = value;
            }
        }
        public override void Initialize()
        {
            base.Initialize();
            PreLoad();
            GameEntry.Event.Subscribe(CreateNewGroundEventArgs.EventId,OnCreateNewGround);
            GameOver = false;
        }

        public override void Update(float elapseSeconds, float realElapseSeconds)
        {
            base.Update(elapseSeconds, realElapseSeconds);
        }

        public override void Shutdown()
        {
            base.Shutdown();
            GameEntry.Event.Unsubscribe(CreateNewGroundEventArgs.EventId,OnCreateNewGround);
            // 隐藏所有实体
            GameEntry.Entity.HideAllLoadingEntities();
            GameEntry.Entity.HideAllLoadedEntities();
        }

        private void OnCreateNewGround(object sender, GameEventArgs e)
        {
            CreateGround();  
        }

        /// <summary>
        /// 加载游戏资源
        /// </summary>
        private void PreLoad()
        {
            //加载player
            GameEntry.Entity.ShowPlayer(new PlayerData(GameEntry.Entity.GenerateSerialId(), 1, Vector3.forward));
            GameHotfixEntry.Ground.Reset();
            GameHotfixEntry.Camera.MainCamera.transform.position = Vector3.zero;
            //初始位置的Ground
            GameHotfixEntry.Ground.LoadGround(new Vector3(0, -3, 1), GroundType.Normal);
            GameEntry.Entity.ShowDeathGround(new DeathGroundData(GameEntry.Entity.GenerateSerialId(), 3,
                new Vector3(0, -5.5f, 1), (int)GroundType.DeathGround));

            for (int i = 0; i < 10; i++)
            {
                CreateGround();
            }
        }
        
        
        private void CreateGround()
        {
            GameHotfixEntry.Ground.CreateGround();
        }

    }
}