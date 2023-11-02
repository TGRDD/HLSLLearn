using Unity.VisualScripting;
using UnityEngine;

namespace PlayerControllable
{

    public interface IMovementSystem
    {
        void Move(Vector3 Direction);
    }
}
