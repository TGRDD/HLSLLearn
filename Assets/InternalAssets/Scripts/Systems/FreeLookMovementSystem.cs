using PlayerControllable;
using UnityEngine;
using System;
using Zenject;

public class FreeLookMovementSystem : IMovementSystem
{
    private Transform _controllableObject;
    private float _fixedspeed;
    private float _speed;
    private float _sensivity;

    private Vector3 _forwardInputVector;
    private Vector3 _rightInputVector;

    private IInputSystem _inputSystem;

    private float mouseX, mouseY;

    [Inject]
    public FreeLookMovementSystem(IInputSystem inputSystem)
    {
        _inputSystem = inputSystem;
    }

    public float Speed
    {
        get
        {
            return _speed;
        }
        set
        {
            _speed = value >= 0 ? value : 0;   
        }
    }

    public float Sensivity
    {
        get
        {
            return _sensivity;
        }
        set
        {
            _sensivity = value;
        }
    }

    public void Move()
    {
        //Debug.Log("Move callback");

        Vector3 MoveVector = Vector3.zero;

        //FixSpeed
        _fixedspeed = _speed * Time.fixedDeltaTime;


        // MoveForward;
        _forwardInputVector = _controllableObject.forward * _fixedspeed * _inputSystem.AxisForward;
        
        // MoveRight;
        _rightInputVector = _controllableObject.right * _fixedspeed * _inputSystem.AxisRight;



        //MoveUp
        if (_inputSystem.InputUp()) { MoveVector += Vector3.up * _fixedspeed; }

        Debug.Log(MoveVector);

        //MoveDown
        if (_inputSystem.InputDown()) { MoveVector -= Vector3.up * _fixedspeed; }



        //ApplyVectors
        MoveVector += _forwardInputVector + _rightInputVector;
        _controllableObject.position += MoveVector;




        mouseX += _inputSystem.ViewAxisRight * Sensivity;
        mouseY -= _inputSystem.ViewAxisUp * Sensivity;

        // ќграничиваем угол вращени€ по оси Y от -90 до 90 градусов
        mouseY = Mathf.Clamp(mouseY, -90f, 90f);

        // ѕримен€ем вращение камеры
        _controllableObject.rotation = Quaternion.Euler(mouseY, mouseX, 0f);


        return;
    }

    public void ApplyData(CharacterUnitData Data)
    {
        if (Data.UnitTransform == null) throw new ArgumentNullException($"{nameof(Data.UnitTransform)} ERROR - Value cannot'be null");
        if (Data.MovementSpeed < 0) throw new ArgumentOutOfRangeException($"{this} ERROR - Value cannot'be less than zero");

        _controllableObject = Data.UnitTransform;
        Speed = Data.MovementSpeed;
        Sensivity = Data.Sensivity;
    }
}
