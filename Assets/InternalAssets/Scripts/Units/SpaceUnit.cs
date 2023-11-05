using UnityEngine;

public class SpaceUnit : MonoBehaviour, IContainerEnity
{
    private IBodyBehavior _bodyBehavior;
    

    public void Inizialize()
    {
        _bodyBehavior = new RotatingBody(this);
    }

    private void Awake()
    {
        Inizialize();
    }

    private void FixedUpdate()
    {
        _bodyBehavior.ExecutionBehavior();
    }
}
