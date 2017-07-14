using Zenject;

/// <summary>
/// Represents DI installer for game session.
/// </summary>
public class GameSessionInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<SessionInitializer>().AsSingle();
        Container.Bind<Game>().AsSingle();
    }
}
