public interface ICharacter
{
    bool IsPlayer { get; }
    int Defense { get; }

    void StartTurn();
    void TakeAction(); // This method needs to be implemented in PlayerCharacter
    void TakeDamage(int amount);
}
