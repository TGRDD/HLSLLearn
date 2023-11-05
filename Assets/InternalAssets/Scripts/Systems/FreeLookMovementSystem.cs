using PlayerControllable;
using UnityEngine;
using System;
public class FreeLookMovementSystem : IMovementSystem
{
    private Transform _controllableObject;
    private float _fixedspeed;
    private float _speed;

    private Vector3 _forwardInput;
    private Vector3 _rightInput;

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

    public void Move()
    {
        //Debug.Log("Move callback");

        //FixSpeed
         _fixedspeed = _speed * Time.fixedDeltaTime;


        // MoveForward;
        _forwardInput = _controllableObject.forward * _fixedspeed * Input.GetAxis("Vertical");
        
        // MoveRight;
        _rightInput = _controllableObject.right * _fixedspeed * Input.GetAxis("Horizontal");
        
        //MoveUp
        if (Input.GetKey(KeyCode.Space)) { _controllableObject.position += Vector3.up * _fixedspeed; }

        //MoveDown
        if (Input.GetKey(KeyCode.LeftControl)) { _controllableObject.position -= Vector3.up * _fixedspeed; }
        
        //ApplyVectors
        _controllableObject.position += _forwardInput + _rightInput;

       
        //RotateLeft
        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            _controllableObject.Rotate(0, -1, 0);
        }
        
        //RotateRight
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _controllableObject.Rotate(0, 1, 0);
        }


        return;
    }

    public void ApplyData(CharacterUnitData Data)
    {
        if (Data.UnitTransform == null) throw new ArgumentNullException($"{nameof(Data.UnitTransform)} ERROR - Value cannot'be null");
        if (Data.MovementSpeed < 0) throw new ArgumentOutOfRangeException($"{this} ERROR - Value cannot'be less than zero");

        _controllableObject = Data.UnitTransform;
        Speed = Data.MovementSpeed;
    }
}
