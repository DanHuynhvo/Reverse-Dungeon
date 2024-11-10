using UnityEngine;

public class EventManager : MonoBehaviour
{
    public DialogManager dialogManager;
    public Dialog highAffectionDialogue;
    public Dialog lowAffectionDialogue;

    public void TriggerEventBasedOnAffection(AffectionSystem suitorAffection)
    {
        if (suitorAffection.affectionPoints >= 10)
        {
            dialogManager.StartDialogue(highAffectionDialogue);
        }
        else if (suitorAffection.affectionPoints <= -10)
        {
            dialogManager.StartDialogue(lowAffectionDialogue);
        }
    }
}

