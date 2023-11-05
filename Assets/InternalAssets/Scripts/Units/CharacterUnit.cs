using PlayerControllable;
using UnityEngine;
using Zenject;

public class CharacterUnit : MonoBehaviour
{
    [SerializeField, Min(0)] private float _speed;

    private IMovementSystem _movementSystem;

    [Inject]
    public void Inizialize(IMovementSystem MovementSystem)
    {
        _movementSystem = MovementSystem;

        CharacterUnitData InitData = new CharacterUnitData(transform, _speed);
        _movementSystem.ApplyData(InitData);
    }

    private void Update()
    {
        _movementSystem.Move();
    }

    public void ChangeSpeed(float NewSpeed)
    {
        _movementSystem.Speed = NewSpeed;
    }
    
}
