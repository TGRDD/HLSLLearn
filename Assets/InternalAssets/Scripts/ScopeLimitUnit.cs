using System;
using UnityEngine;

public class ScopeLimitUnit : MonoBehaviour
{
    [SerializeField] private float _minXPosition;
    [SerializeField] private float _maxXPosition;

    private IScopeLimiter _scopeLimiterSystem;

    public void Inizialize()
    {
        if (_minXPosition > _maxXPosition) throw new ArgumentException($"ERROR - {gameObject.name} The minimum position cannot be greater than the maximum"); 
        _scopeLimiterSystem = new ScopeLimiterSystem(transform, _maxXPosition, _minXPosition);
    }

    public void Start()
    {
        Inizialize();
    }

    private void Update()
    {
        _scopeLimiterSystem.LimitScope();
    }



    private void OnDrawGizmos()
    {
        Vector3 limitPosition = transform.position;

        Gizmos.color = _minXPosition > _maxXPosition ? Color.red : Color.green;

        limitPosition.x = _maxXPosition;
        Gizmos.DrawSphere(limitPosition, 0.1f);
        limitPosition.x = _minXPosition;
        Gizmos.DrawSphere(limitPosition, 0.1f);
    }
}
