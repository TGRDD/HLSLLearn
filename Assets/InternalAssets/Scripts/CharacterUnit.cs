using System;
using PlayerControllable;
using UnityEngine;

public class CharacterUnit : MonoBehaviour
{
    [SerializeField, Min(0)] private float speed;

    private IMovementSystem _movementSystem;
    private Vector3 _direction = Vector3.zero;

    public void Start()
    {
        _movementSystem = new DefaultMovementSystem(transform, speed);    
    }

    private void Update()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _movementSystem.Move(_direction);
    }
    
}
