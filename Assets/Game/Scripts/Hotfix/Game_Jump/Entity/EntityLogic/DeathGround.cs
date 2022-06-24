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
    }
}