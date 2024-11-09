using UnityEngine;

public class RangedAttack : MonoBehaviour,IAttack
{
   
    public int damage;
    public float range;

   // public GameObject projectilePrefab;
    

    public float Range => range;

    public void Attack(Transform target){

        Debug.Log("Ranged Attack! Dealing" + damage + " damage to the Player");
    }


}
