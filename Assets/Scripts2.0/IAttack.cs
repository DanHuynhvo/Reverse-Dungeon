using UnityEngine;

public interface IAttack
{
    string AttackName { get; }
    int Damage { get; }
    int Cost { get; }
    int Range { get; }
    bool IsAOE { get; }
    int AOESize { get; } // Defines the area size if it is an AOE attack

    void Execute(ICharacter target);
}

