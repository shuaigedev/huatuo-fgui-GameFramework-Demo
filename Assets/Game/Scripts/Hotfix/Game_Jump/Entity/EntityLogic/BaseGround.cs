using UnityEngine;
using UnityGameFramework.Runtime;

namespace Game.Hotfix
{
    public class BaseGround : Entity
    {
        [SerializeField] private GroundData m_GroundData = null;

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            m_GroundData = userData as GroundData;
            if (m_GroundData == null)
            {
                Log.Error("Ground object data is invalid.");
                return;
            }
            
            transform.localPosition = m_GroundData.GroundPosition;
        }
    }
}