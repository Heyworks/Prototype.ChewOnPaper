using Zenject;

public class RoomsInitializer : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IRoomsProvider>().FromFactory<RoomProvidersFactory>().AsSingle();
        Container.Bind<MainScreenPresenter>().AsTransient();
    }
}
