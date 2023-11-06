using PlayerControllable;
using UnityEngine;
using Zenject;

public class CharacterUnit : MonoBehaviour
{
    [SerializeField, Min(0)] private float _speed;
    [SerializeField, Min(0)] private float _sensivity;

    private IMovementSystem _currentMovementSystem;

    private PlanetsFollowMovementSystem _followMovementSystem;
    private FreeLookMovementSystem _freeLookMovementSystem;

    //DATA
    private CharacterUnitData _initData;

    private void OnEnable()
    {
        MoveTypeChangeButton.OnNewTypeSend += ChangeMovementSystem;
    }

    private void OnDisable()
    {
        MoveTypeChangeButton.OnNewTypeSend -= ChangeMovementSystem;
    }

    [Inject]
    public void Inizialize(IInputSystem inputSystem)
    {
        _followMovementSystem = new PlanetsFollowMovementSystem(inputSystem);
        _freeLookMovementSystem = new FreeLookMovementSystem(inputSystem);

        _currentMovementSystem = _followMovementSystem;

        _initData = new CharacterUnitData(transform, _speed, _sensivity);
        _currentMovementSystem.ApplyData(_initData);



    }

    private void Update()
    {
        _currentMovementSystem.Move();
    }

    public void ChangeSpeed(float NewSpeed)
    {
        _currentMovementSystem.Speed = NewSpeed;
    }

    public void ChangeMovementSystem(MoveType NewType)
    {
        switch (NewType)
        {
            case MoveType.FreeCam:
                _currentMovementSystem = _freeLookMovementSystem;
                _freeLookMovementSystem.ApplyData(_initData);
                break;

            case MoveType.PlanetFollow:
                _currentMovementSystem = _followMovementSystem;
                _freeLookMovementSystem.ApplyData (_initData);
                break;


            default: break;
        }
    }



}
