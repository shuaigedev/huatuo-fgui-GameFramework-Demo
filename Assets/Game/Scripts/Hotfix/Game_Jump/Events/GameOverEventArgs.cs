using GameFramework.Event;

namespace Game.Hotfix
{
    public class GameOverEventArgs: GameEventArgs
    {
        
        public static readonly int EventId = typeof(GameOverEventArgs).GetHashCode();
        
        public override void Clear()
        {
           
        }

        public override int Id 
        {
            get { return EventId; }
        }
    }
}