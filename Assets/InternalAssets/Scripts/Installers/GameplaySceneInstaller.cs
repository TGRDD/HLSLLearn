using PlayerControllable;
using UnityEngine;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{

    private void Awake()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

    }

    public override void InstallBindings()
    {
        
        //DesktopLoad
        Container.Bind<IInputSystem>().To<DesktopInputSystem>().AsSingle();

    }
}
