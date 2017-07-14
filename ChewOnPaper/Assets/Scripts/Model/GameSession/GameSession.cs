using Zenject;

public class GameSession
{
    private readonly IFactory<SessionStateData, GameSessionState> stateFactory;

    public GameSession(IFactory<SessionStateData, GameSessionState> stateFactory)
    {
        this.stateFactory = stateFactory;
    }

    public GameSessionState CurrentState
    {
        get;
        private set;
    }

    public void ChangeState(SessionStateData data)
    {
        CurrentState = stateFactory.Create(data);
        CurrentState.Initialize();
    }

}
