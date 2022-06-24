using GameFramework.Event;

namespace Game.Hotfix
{
    public class StartGameEventArgs : GameEventArgs
    {

        public static readonly int EventId = typeof(StartGameEventArgs).GetHashCode();


        public override int Id
        {
            get { return EventId; }
        }

        public override void Clear()
        {

        }

        public StartGameEventArgs Fill()
        {
            return this;
        }

    }
}