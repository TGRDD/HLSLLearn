using UnityEngine;

public class RotatingBody : IBodyBehavior
{

    private SpaceUnit _controllableSpaceUnit;

    public RotatingBody(SpaceUnit spaceUnit)
    {
        _controllableSpaceUnit = spaceUnit;
    }


    public void ExecutionBehavior()
    {
        _controllableSpaceUnit.transform.Rotate(0, 0, 1);
    }    
}
