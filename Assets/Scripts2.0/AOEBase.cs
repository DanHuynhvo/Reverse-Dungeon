using UnityEngine;

public class AOEAttack : IAttack
{
    public string AttackName => "Fireball";
    public int Damage { get; private set; }
    public int Cost => 1;
    public int Range => 5; // Long-range AOE attack
    public bool IsAOE => true;
    public int AOESize { get; private set; }

    public AOEAttack(int damage, int aoeSize)
    {
        Damage = damage;
        AOESize = aoeSize;
    }

    public void Execute(ICharacter target)
    {
        // Apply damage to the target and potentially to other characters within AOESize
        target.TakeDamage(Damage);
        Debug.Log($"{AttackName} deals {Damage} AOE damage to {target} and nearby enemies within {AOESize} units.");
    }
}
