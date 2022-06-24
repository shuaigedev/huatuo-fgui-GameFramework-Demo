using System.Collections.Generic;
using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Game.Hotfix
{
    /// <summary>
    /// 生成一个普通地板
    /// </summary>
    public class CreateNormalGround : ICreateGround
    {
        public GroundDataList GetCreateGroundDatas(float locationY)
        {
            GroundDataList groundDataList = ReferencePool.Acquire<GroundDataList>();

            float x = Random.Range(-2f,2f);
            
            groundDataList.Add(new Vector3(x,locationY,1f),2);
            
            return groundDataList;
        }

        public void Clear()
        {
            
        }
    }
}