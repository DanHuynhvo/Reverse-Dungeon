using UnityEngine;

public class SwordAttack : IAttack
{
    public string AttackName => "Sword Slash";
    public int Damage { get; private set; }
    public int Cost => 5;
    public int Range => 1;
    public bool IsAOE => false;
    public int AOESize => 0;

    public SwordAttack(int damage)
    {
        Damage = damage;
    }

    // This method needs a return type, which in this case should be 'void'
    public void Execute(ICharacter target)
    {
        target.TakeDamage(Damage);
        Debug.Log($"{AttackName} deals {Damage} damage to {target}");
    }
}
