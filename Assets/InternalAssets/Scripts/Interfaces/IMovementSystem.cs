namespace PlayerControllable
{

    public interface IMovementSystem
    {
        float Speed { get; set; }
        void Move();

        void ApplyData(CharacterUnitData Data);

    }
}
