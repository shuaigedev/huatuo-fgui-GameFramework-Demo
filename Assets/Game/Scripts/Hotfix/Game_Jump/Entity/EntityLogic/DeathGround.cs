using UnityEngine;
using UnityGameFramework.Runtime;

namespace Game.Hotfix
{
    public class DeathGround : BaseGround
    {
        private void Update()
        {
            //始终处于摄像机下面一点点
            transform.SetPositionY(GameHotfixEntry.Camera.MainCamera.transform.position.y-5.5f);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            transform.localScale = new Vector3(10, 1, 1);
        }
    }
}