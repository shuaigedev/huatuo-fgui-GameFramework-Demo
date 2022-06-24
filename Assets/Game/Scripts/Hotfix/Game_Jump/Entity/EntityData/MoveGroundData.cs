using UnityEngine;

namespace Game.Hotfix
{
    public class MoveGroundData : GroundData 
    {
        public MoveGroundData(int entityId, int typeId, Vector3 position, int type) : base(entityId, typeId, position, type)
        {
        }
    }
}