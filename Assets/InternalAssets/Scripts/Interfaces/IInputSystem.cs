public interface IInputSystem
{
    float AxisForward { get; set; }
    float AxisRight { get; set; }

    float ViewAxisRight { get; set; }
    float ViewAxisUp { get; set; }

    public bool InputUp();
    public bool InputDown();

    public bool InteractKey();


    
}
