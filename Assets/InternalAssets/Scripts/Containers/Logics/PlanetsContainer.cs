using System.Collections.Generic;

public class PlanetsContainer : IContainer
{
    public List<IContainerEnity> Container { get; set; }


    public IContainerEnity[] GetContainer() { return null; }
    public void SetContainer(List<IContainerEnity> container) 
    { 
        Container = container;
    }
    public void AddEntity<T>(T Entity) where T : IContainerEnity 
    { 
        Container.Add(Entity);
    }

    public void RemoveEntity<T>(T Entity) where T : IContainerEnity 
    { 
        Container.Remove(Entity);
    } 
}
