using Zenject;

/// <summary>
/// Represents DI installer for rooms.
/// </summary>
public class RoomsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IRoomsProvider>().FromFactory<RoomProvidersFactory>().AsSingle();
        Container.Bind<MainScreenPresenter>().AsTransient();
    }
}
