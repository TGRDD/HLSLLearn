using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScopeLimiterSystem : IScopeLimiter
{
    private Transform _RestrictedObject;

    private Vector3 _limitedVector = Vector3.zero;

    private float _maxX;
    private float _minX;


    public ScopeLimiterSystem(Transform RestrictedObject, float XMaxCoordinateLimit, float XMinCoordinateLimit) 
    { 
        _RestrictedObject = RestrictedObject;

        _maxX = XMaxCoordinateLimit;
        _minX = XMinCoordinateLimit;
    }


    public void LimitScope()
    {
        _limitedVector = _RestrictedObject.position;
        _limitedVector.x = Mathf.Clamp(_limitedVector.x, _minX, _maxX);

        _RestrictedObject.position = _limitedVector;
    }
}
