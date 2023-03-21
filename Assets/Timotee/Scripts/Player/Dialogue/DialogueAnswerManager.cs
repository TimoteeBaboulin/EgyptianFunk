using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueAnswerManager : MonoBehaviour, IDialogue{
    public TextMeshProUGUI AnswerText;
    public Button Button;
    public event Action OnClick;

    public void SetText(string text){
        AnswerText.text = text;

        Button.onClick.AddListener(() => {OnClick?.Invoke();});
    }

    private void OnDisable(){
        OnClick = null;
    }
}

public interface IDialogue{
    public void SetText(string text);
}