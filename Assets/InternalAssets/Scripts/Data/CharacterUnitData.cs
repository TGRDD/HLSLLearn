using JetBrains.Annotations;
using UnityEngine;

public class CharacterUnitData
{

    public CharacterUnitData(Transform UnitTransform, float MovementSpeed, float Sensivity)
    {
        this.UnitTransform = UnitTransform;
        this.MovementSpeed = MovementSpeed;
        this.Sensivity = Sensivity;
    }

    public float MovementSpeed;
    public Transform UnitTransform;
    public float Sensivity;
}
