using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AffectionSystem[] suitors;

    public void ModifySuitorAffection(int suitorIndex, int amount)
    {
        suitors[suitorIndex].ModifyAffection(amount);
    }
}
