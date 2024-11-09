using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player instance;
    public string direction = "";
    void Awake()
    {
        instance = this;
    }


}
