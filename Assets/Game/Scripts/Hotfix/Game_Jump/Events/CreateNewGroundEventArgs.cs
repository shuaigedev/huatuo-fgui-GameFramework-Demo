using GameFramework.Event;

namespace Game.Hotfix
{
    /// <summary>
    /// 创建新地板事件
    /// </summary>
    public class CreateNewGroundEventArgs : GameEventArgs
    {
        
        public static readonly int EventId = typeof(CreateNewGroundEventArgs).GetHashCode();
        
        public override void Clear()
        {
           
        }

        public override int Id 
        {
            get { return EventId; }
        }
    }
}