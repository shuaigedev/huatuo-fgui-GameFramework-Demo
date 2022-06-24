using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Game.Hotfix
{
    public class Ground : BaseGround
    {
        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.tag == "DeathGround")
            {
                //地板触碰到死亡地板的时候会隐藏 并发出通知 生成新地板
                GameEntry.Entity.HideEntity(this);
                GameEntry.Event.Fire(this,ReferencePool.Acquire<CreateNewGroundEventArgs>());
            }
        }
    }
}