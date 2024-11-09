using UnityEngine;

public class Weapon : MonoBehaviour, IAttack
{
    public string name;
    public float damage;
    public Vector2 range;
    public LayerMask enemy;

    public void Attack()
    {
    }

    public void Equip()
    {

    }

    public void AOE()
    {
        //checks if there is an enemy in range
        if (Physics2D.OverlapBox((Vector2)Player.instance.transform.position, range, enemy))
        {
            
        }
    }
}
