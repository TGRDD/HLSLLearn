
using System.Collections.Generic;

public interface IContainer
{
    List<IContainerEnity> Container { get; set; }


    public IContainerEnity[] GetContainer();

    public void SetContainer(List<IContainerEnity> NewContainer);

    public void AddEntity<T>(T Enity) where T : IContainerEnity;

    public void RemoveEntity<T>(T Entity) where T : IContainerEnity;
}
