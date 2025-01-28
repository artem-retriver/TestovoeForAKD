using Zenject;

public class GaragePickupGameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PlayerController>().AsSingle();
        Container.Bind<InteractionHandler>().AsSingle();
    }
}