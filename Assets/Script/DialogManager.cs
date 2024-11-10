using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text speakerText;
    public Text dialogueText;
    public GameObject[] choiceButtons; // Link UI buttons for choices

    private Dialog currentLine;

    public void StartDialogue(Dialog startLine)
    {
        currentLine = startLine;
        DisplayLine(currentLine);
    }

    private void DisplayLine(Dialog line)
    {
        speakerText.text = line.speakerName;
        dialogueText.text = line.line;
        SetUpChoices(line.choices);
    }

    private void SetUpChoices(Dialog[] choices)
    {
        for (int i = 0; i < choiceButtons.Length; i++)
        {
            if (i < choices.Length)
            {
                choiceButtons[i].SetActive(true);
                choiceButtons[i].GetComponentInChildren<Text>().text = choices[i].line;
                int choiceIndex = i;
                choiceButtons[i].GetComponent<Button>().onClick.AddListener(() => ChooseNextLine(choiceIndex));
            }
            else
            {
                choiceButtons[i].SetActive(false);
            }
        }
    }

    private void ChooseNextLine(int choiceIndex)
    {
        currentLine = currentLine.choices[choiceIndex];
        DisplayLine(currentLine);
    }
}
