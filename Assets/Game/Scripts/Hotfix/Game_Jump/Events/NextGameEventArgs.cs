using GameFramework.Event;

public class NextGameEventArgs : GameEventArgs
{
    public static readonly int EventId = typeof(NextGameEventArgs).GetHashCode();


    public override int Id
    {
        get { return EventId; }
    }

    private int m_NextGameId;

    public int NextGameId
    {
        get { return m_NextGameId; }
        set { m_NextGameId = value; }
    }

    public override void Clear()
    {
        m_NextGameId = 0;
    }

    public NextGameEventArgs Fill(int nextgameid)
    {
        m_NextGameId = nextgameid;
        return this;
    }
}
