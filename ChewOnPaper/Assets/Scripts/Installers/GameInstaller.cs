using Zenject;

/// <summary>
/// Represents DI installer for game session.
/// </summary>
public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindFactory<StateParameters, GameState, GameState.GameStateFactory>().FromFactory<CustomGameStateFactory>();
        Container.Bind<MasterStateMachine>().AsSingle();
        Container.Bind<GuessChat>().AsSingle();
        Container.Bind<Game>().AsSingle();
    }
}
