using PlayerControllable;
using System;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class PlanetsFollowMovementSystem : IMovementSystem
{
    public float Speed { get; set; }

    private ContainerUnit _planetsContainer;

    //DATA
    private Transform _controllableObject;

    //Control
    private IInputSystem _inputSystem;
    private int _currentPlanetIndex;
    private int MaxIndex;
    private Transform _currentPlanet;

    //Interaction
    private float UpMove;
    private float RightMove;
    private float _sensivity;
    private bool _readyToControl = true;

    [Inject]
    public PlanetsFollowMovementSystem(IInputSystem inputSystem)
    {
        _inputSystem = inputSystem;
    }

    public async void Move()
    {
        if (_planetsContainer == null) return;
        if (!_readyToControl) return;

        MaxIndex = _planetsContainer._container.Container.Count - 1;

        if (_inputSystem.InteractKey())
        {
            _currentPlanetIndex = _currentPlanetIndex++ == MaxIndex ? 0 : _currentPlanetIndex++;

            _currentPlanet = _planetsContainer._container.Container[_currentPlanetIndex].transform;
            await SmoothFlyToNextPlanet(_currentPlanet);
            return;
        }

        _currentPlanet = _planetsContainer._container.Container[_currentPlanetIndex].transform;
        Vector3 AddedDistance = Vector3.up * UpMove + Vector3.right * RightMove;

        _controllableObject.position = _currentPlanet.position + AddedDistance;
        _controllableObject.LookAt(_currentPlanet);

        UpMove += _inputSystem.ViewAxisUp * Time.deltaTime * _sensivity;
        UpMove = Mathf.Clamp(UpMove, -5, 5);

        RightMove += _inputSystem.ViewAxisRight * Time.deltaTime * _sensivity;
        RightMove = Mathf.Clamp(RightMove, -5, 5);


    }

    public async Task SmoothFlyToNextPlanet(Transform NextPlanetTransform)
    {
        _readyToControl = false;
        for (int i = 0; i < 120; i++)
        {
            Vector3 FollowPos = NextPlanetTransform.position + Vector3.up * UpMove + Vector3.right * RightMove;
            _controllableObject.position = Vector3.MoveTowards(_controllableObject.position, FollowPos, Vector3.Distance(_controllableObject.position, NextPlanetTransform.position) / 60);
            await Task.Delay(Convert.ToInt32(Time.deltaTime * 1000));
        }

        for (float i = 0; i < 5; i ++)
        {
            Vector3 FollowPos = NextPlanetTransform.position + Vector3.up * UpMove + Vector3.right * RightMove;
            Vector3 SlerpPos = Vector3.Slerp(_controllableObject.position, FollowPos, i / 10);
            _controllableObject.position = SlerpPos;
            await Task.Delay(Convert.ToInt32(Time.deltaTime * 1000));
        }

        _readyToControl = true;
    }

    public void ApplyData(CharacterUnitData characterUnitData)
    {
        _planetsContainer = MonoBehaviour.FindObjectsOfType<ContainerUnit>().FirstOrDefault(container => container.containerType == ContainerType.PlanetContainer);
        if (_planetsContainer == null)
        {
            throw new System.Exception();
        }

        _controllableObject = characterUnitData.UnitTransform;
        _sensivity = characterUnitData.Sensivity;
    }
}
