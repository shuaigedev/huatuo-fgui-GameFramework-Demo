using UnityEngine;

namespace Game.Hotfix
{
    public class CreateGroundManager
    {
        
        
        public CreateGroundManager()
        {
            
        }
        
        
        /// <summary>
        /// 加载地板
        /// </summary>
        /// <param name="position">地板生成位置</param>
        /// <param name="type">地板类型</param>
        public void LoadGround(Vector3 position, GroundType type)
        {
            LoadGround(position, (int) type);
        }

        /// <summary>
        /// 加载地板
        /// </summary>
        /// <param name="position">地板生成位置</param>
        /// <param name="type">地板类型</param>
        public void LoadGround(Vector3 position, int type)
        {
            switch (type)
            {
                case 2 : GameEntry.Entity.ShowGround(new GroundData(GameEntry.Entity.GenerateSerialId(), type, position, type));
                    break;
                case 3 : GameEntry.Entity.ShowDeathGround(new DeathGroundData(GameEntry.Entity.GenerateSerialId(), type, position, type));
                    break;
                case 4 : GameEntry.Entity.ShowMoveGround(new MoveGroundData(GameEntry.Entity.GenerateSerialId(), type, position, type));
                    break;
                case 5 : GameEntry.Entity.ShowGround(new GroundData(GameEntry.Entity.GenerateSerialId(), type, position, type));
                    break;
            }
        }
    }
}