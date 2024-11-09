using UnityEngine;

public class Player : MonoBehaviour
{

    public IAttack chosenAttack;
    public Weapon equipedWeapon;
    public static Player instance;
    public string direction = "";
    void Awake()
    {
        instance = this;
    }


}
