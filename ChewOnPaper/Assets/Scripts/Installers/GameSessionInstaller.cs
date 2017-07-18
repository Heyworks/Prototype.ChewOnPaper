using Zenject;

/// <summary>
/// Represents DI installer for game session.
/// </summary>
public class GameSessionInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<MasterStateMachine>().AsSingle();
        Container.Bind<Game>().AsSingle();
        Container.BindFactory<StateParameters, GameState, GameState.GameStateFactory>()
            .FromFactory<CustomGameStateFactory>();
    }
}
