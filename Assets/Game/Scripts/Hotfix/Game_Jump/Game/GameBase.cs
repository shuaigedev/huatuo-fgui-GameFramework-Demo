//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2019 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework.Event;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Game.Hotfix
{
    public abstract class GameBase
    {
        public abstract GameMode GameMode
        {
            get;
        }

        public abstract int NextGame
        {
            get;
            set;
        }

        //protected ScrollableBackground SceneBackground
        //{
        //    get;
        //    private set;
        //}

        public bool GameOver
        {
            get;
            set;
        }

        public virtual void Initialize()
        {
            
        }

        public virtual void Shutdown()
        {
   
        }

        public virtual void Update(float elapseSeconds, float realElapseSeconds)
        {
           
        }

        protected virtual void OnShowEntitySuccess(object sender, GameEventArgs e)
        {
            
        }

        protected virtual void OnShowEntityFailure(object sender, GameEventArgs e)
        {
            
        }
    }
}
