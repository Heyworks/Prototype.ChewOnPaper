using Zenject;

/// <summary>
/// Represents DI installer for game session.
/// </summary>
public class GameSessionInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GameStateMachine>().AsSingle();
        Container.Bind<Game>().AsSingle();
    }
}
