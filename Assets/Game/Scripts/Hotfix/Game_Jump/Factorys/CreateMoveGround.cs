
using GameFramework;
using UnityEngine;

namespace Game.Hotfix
{
    public class CreateMoveGround : ICreateGround
    {
        private readonly float m_Left = -2f;

        private readonly float m_Right = 2f;
        
        public GroundDataList GetCreateGroundDatas(float locationY)
        {
            GroundDataList groundDataList = ReferencePool.Acquire<GroundDataList>();

            double rand = Utility.Random.GetRandomDouble();

            float x = rand > 0.5 ? m_Left : m_Right;
            
            groundDataList.Add(new Vector3(x,locationY,1f),4);
            
            return groundDataList;
        }

        public void Clear()
        {
            
        }
    }
}