using UnityEngine;

[CreateAssetMenu(fileName = "Dialog", menuName = "Dialogue/Line",order = 1)]
public class Dialog : ScriptableObject
{
    public string speakerName;
    [TextArea(3, 10)]
    public string line;
    public Dialog[] choices; // Next lines based on choices
}