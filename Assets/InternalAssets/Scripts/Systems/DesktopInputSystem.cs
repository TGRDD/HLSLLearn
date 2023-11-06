using Unity.VisualScripting;
using UnityEngine;

public class DesktopInputSystem : IInputSystem
{
    public float AxisRight { get { return Input.GetAxis("Horizontal"); } set { } }
    public float AxisForward { get { return Input.GetAxis("Vertical"); } set { } }

    public float ViewAxisRight { get { return Input.GetAxis("Mouse X"); } set { } }
    public float ViewAxisUp { get { return Input.GetAxis("Mouse Y"); } set { } }

    public bool InputUp()
    {
        return Input.GetKey(KeyCode.Space);
    }

    public bool InputDown()
    {
        return Input.GetKey(KeyCode.LeftControl);
    }

    public bool InteractKey()
    {
        return Input.GetMouseButtonDown(0);
    }


}
