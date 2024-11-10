using UnityEngine;

using UnityEngine;

public class RangedAttack : IAttack
{
    public string AttackName => "Ranged Shot";
    public int Damage { get; private set; }
    public int Cost => 10;
    public int Range => 5;
    public bool IsAOE => false;
    public int AOESize => 0;

    public RangedAttack(int damage)
    {
        Damage = damage;
    }

    public void Execute(ICharacter target)
    {
        target.TakeDamage(Damage);
        Debug.Log($"{AttackName} deals {Damage} damage to {target}");
    }
}

