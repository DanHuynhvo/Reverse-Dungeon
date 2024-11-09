using UnityEngine;

public class MeleeAttack : MonoBehaviour,IAttack
{
    public int damage;
    public float range;

    public float Range => range;

    public void Attack(Transform target){

        Debug.Log("Melee Attack! Dealing" + damage + " damage to the Player");
    }
}
