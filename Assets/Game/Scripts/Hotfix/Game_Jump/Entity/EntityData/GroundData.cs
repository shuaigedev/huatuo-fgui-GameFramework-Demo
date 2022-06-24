using UnityEngine;

namespace Game.Hotfix
{

    public enum GroundType
    {
        Normal = 2,
        DeathGround = 3,
        MoveGround = 4,
    }

    public class GroundData : EntityData
    {

        private int m_Type;

        public int Type
        {
            get { return m_Type; }
            set { m_Type = value; }
        }

        /// <summary>
        /// 生成位置
        /// </summary>
        private Vector3 m_GroundPosition;

        public Vector3 GroundPosition
        {
            get { return m_GroundPosition; }
            set { m_GroundPosition = value; }
        }


        public GroundData(int entityId, int typeId,Vector3 position,int type) : base(entityId, typeId)
        {
            m_GroundPosition = position;
            m_Type = type;
        }
    }
}