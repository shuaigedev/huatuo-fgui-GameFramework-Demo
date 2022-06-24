using UnityEngine;

namespace Game.Hotfix
{
    public class PlayerData : EntityData
    {
        private Vector3 m_StartLocation;

        public Vector3 StartLocation
        {
            get { return m_StartLocation; }
            set { m_StartLocation = value; }
        }


        public PlayerData(int entityId, int typeId,Vector3 startLocation) : base(entityId, typeId)
        {
            m_StartLocation = startLocation;
        }
    }
}