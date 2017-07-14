using Zenject;

/// <summary>
/// Represents init state of game state machine.
/// </summary>
public class GameInitState : GameState
{
    [Inject]
    private SessionInitializer sessionInitializer;

    [Inject]
    private Game game;

    public override void Acticate()
    {
        base.Acticate();
        var session = sessionInitializer.InitializeSession(game.Players);
    }
}