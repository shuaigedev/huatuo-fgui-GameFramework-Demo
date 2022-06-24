using System.Collections.Generic;
using GameFramework;
using UnityEngine;

namespace Game.Hotfix
{
    public class GroundDataList : List<CreateGroundData>, IReference
    {
        public void Add(Vector3 location,int type)
        {
            Add(ReferencePool.Acquire<CreateGroundData>().Fill(location,type));
        }
        public new void Clear()
        {
            foreach (var item in this)
            {
                ReferencePool.Release((IReference) item);
            }

            base.Clear();
        }
    }


    /// <summary>
    /// 地板数据基类
    /// </summary>
    public class CreateGroundData : IReference
    {
        /// <summary>
        /// 地板生成位置
        /// </summary>
        private Vector3 m_GroundLocation;
        /// <summary>
        /// 地板类型
        /// </summary>
        private int m_GroundType;
        
        public Vector3 GroundLocation
        {
            get { return m_GroundLocation; }
            set { m_GroundLocation = value; }
        }

        public int GroundType
        {
            get { return m_GroundType; }
            set { m_GroundType = value; }
        }

        public CreateGroundData Fill(Vector3 groundLocation, int groundType)
        {
            m_GroundLocation = groundLocation;
            m_GroundType = groundType;
            return this;
        }

        public void Clear()
        {
            m_GroundLocation = Vector3.zero;
            m_GroundType = 0;
        }
    }
}