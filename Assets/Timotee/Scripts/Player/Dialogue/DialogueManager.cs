using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour{
    [SerializeField] public float TalkingSpeed;
    
    private Dialogue _currentDialogue;

    public void ChooseAnswer(int answer){
        
    }

    private IEnumerator DisplayMessageCoroutine(){
        yield return null;
    }
}

public enum DialogueSide{
    Left = 0,
    Right = 1
}

public class Dialogue : ScriptableObject{
    public bool IsQuestion;

    public string CharacterName;
    public DialogueSide Side;

    public string[] Lines;
    public bool[] IsLineAnswer;

    public Dialogue[] NextDialogue;
}

public class UIDialogueWriter : MonoBehaviour{
    [Header("Used for Debug")]
    [SerializeField] private Dialogue _dialogue;
    [Header("Names and Header")]
    [SerializeField] private TextMeshProUGUI[] _names;
    [SerializeField] private Image[] _nameSquares;
    [SerializeField] private Color _activeColor;
    [SerializeField] private Color _inactiveColor;
    private string _lastName;
    
    [Header("Body of the text")]
    [SerializeField] private TextMeshProUGUI[] _lines;

    public bool IsRunning => _isRunning;
    private bool _isRunning;

    public void StartNewDialogue(Dialogue dialogue, DialogueManager context){
        _dialogue = dialogue;
        
        if (_lastName != dialogue.name){
            ushort id = (ushort) dialogue.Side;
            _names[id].text = dialogue.name;
            _nameSquares[id].color = _activeColor;
            _nameSquares[id == 0 ? 1 : 0].color = _inactiveColor;
        }
    }

    public IEnumerator WritingCoroutine(DialogueManager manager){
        float timer = 0;
        int answer = 0;
        _isRunning = true;
        
        for (int l = 0; l < _dialogue.Lines.Length; l++){
            int index = 0;
            TextMeshProUGUI line = _lines[l];
            string text = _dialogue.Lines[l];

            if (_dialogue.IsLineAnswer[l]){
                line.GetComponent<Button>().onClick.AddListener(() => {
                    manager.ChooseAnswer(answer);
                    answer++;
                });

                line.text = text;
                continue;
            }
            
            while (index < text.Length){
                yield return new WaitForSecondsRealtime(1 / manager.TalkingSpeed);
            }
        }

        _isRunning = false;
        yield break;
    }
    
    
    
    public void ExitDialogueScreen(){
        
    }
}
