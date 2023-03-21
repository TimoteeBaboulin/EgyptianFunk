using TMPro;
using UnityEngine;

public class DialogueNormalManager : MonoBehaviour, IDialogue{
    public TextMeshProUGUI TextMeshPro;

    public string text{
        get{
            return TextMeshPro.text;
        }
        set{
            TextMeshPro.text = value;
        }
    }

    public void SetText(string text){
        TextMeshPro.text = text;
    }
}