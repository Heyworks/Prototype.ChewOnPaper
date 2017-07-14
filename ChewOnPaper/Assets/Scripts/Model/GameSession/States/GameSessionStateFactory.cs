using Zenject;

public class GameSessionStateFactory : IFactory<SessionStateData, GameSessionState>
{
    public GameSessionState Create(SessionStateData data)
    {
        throw new System.NotImplementedException();
    }
}

