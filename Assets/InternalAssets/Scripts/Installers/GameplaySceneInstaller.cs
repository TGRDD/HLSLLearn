using PlayerControllable;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IMovementSystem>().To<FreeLookMovementSystem>().AsSingle();
    }
}
