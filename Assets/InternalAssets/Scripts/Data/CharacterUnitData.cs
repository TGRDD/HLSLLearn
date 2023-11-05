using JetBrains.Annotations;
using UnityEngine;

public class CharacterUnitData
{

    public CharacterUnitData(Transform UnitTransform, float MovementSpeed)
    {
        this.UnitTransform = UnitTransform;
        this.MovementSpeed = MovementSpeed;
    }

    public float MovementSpeed;
    public Transform UnitTransform;
}
