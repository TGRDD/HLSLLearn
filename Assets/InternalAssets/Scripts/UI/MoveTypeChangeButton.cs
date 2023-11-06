using System;

public class MoveTypeChangeButton : ButtonWriter
{
    public MoveType type;

    public static Action<MoveType> OnNewTypeSend;

    protected override void ClickEvent()
    {
        OnNewTypeSend?.Invoke(type);
    }
}
