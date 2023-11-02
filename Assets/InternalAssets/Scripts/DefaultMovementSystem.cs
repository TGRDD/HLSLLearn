using PlayerControllable;
using UnityEngine;

public class DefaultMovementSystem : IMovementSystem
{
    private Transform _controllableObject;
    private float _speed;

    

    public DefaultMovementSystem(Transform ControllableObject, float DefaultSpeed) 
    { 
        _controllableObject = ControllableObject;
        _speed = DefaultSpeed;
    }

    public void Move(Vector3 Direction)
    {
        _controllableObject.Translate(Direction * _speed * Time.deltaTime);
    }
}
