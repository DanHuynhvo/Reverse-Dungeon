using UnityEngine;

public class AffectionSystem : MonoBehaviour
{
    public int affectionPoints;

    public void ModifyAffection(int change)
    {
        affectionPoints += change;
        CheckAffectionLevel();
    }

    private void CheckAffectionLevel()
    {
        if (affectionPoints >= 10)
        {
            Debug.Log("Character is very interested!");
        }
        else if (affectionPoints <= -10)
        {
            Debug.Log("Character is losing interest.");
        }
    }
}
