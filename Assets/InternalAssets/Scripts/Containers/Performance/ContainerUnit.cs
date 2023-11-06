using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ContainerType
{
    PlanetContainer
}

public class ContainerUnit : MonoBehaviour
{

    [field: SerializeField] public ContainerType containerType { get; private set; }
    [SerializeField] private List<IContainerEnity> DefaultItems;
    public IContainer _container { get; private set; }

    private void Awake()
    {
        switch (containerType)
        {
            case ContainerType.PlanetContainer:
                _container = new PlanetsContainer();
                SetDefaultItems();

                break;

            default: break;
        }
    }

    private void SetDefaultItems()
    {
        _container.SetContainer(DefaultItems);
    }
}
