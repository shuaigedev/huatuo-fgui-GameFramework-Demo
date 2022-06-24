using GameFramework.Event;

namespace Game.Hotfix
{
    /// <summary>
    /// 分数增加事件
    /// </summary>
    public class UpScoreEventArgs: GameEventArgs
    {
        
        public static readonly int EventId = typeof(UpScoreEventArgs).GetHashCode();
        
        
        public override int Id 
        {
            get { return EventId; }
        }

        private int m_Score;

        public int Score
        {
            get { return m_Score; }
            set { m_Score = value; }
        }

        public override void Clear()
        {
            m_Score = 0;
        }

        public UpScoreEventArgs Fill(int score)
        {
            m_Score = score;
            return this;
        }

    }
}