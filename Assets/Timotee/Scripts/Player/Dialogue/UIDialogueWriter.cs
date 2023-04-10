using System.Collections;
using Timotee.Scripts.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDialogueWriter : MonoBehaviour{
    public static UIDialogueWriter Instance;

    [SerializeField] private GameObject _dialogueUiParent;
    
    [Header("Writing Settings")] 
    [SerializeField] private float _writingSpeed;
    
    [Header("Used for Debug")]
    [SerializeField] private Dialogue _dialogue;
    
    [Header("Names and Header")]
    [SerializeField] private TextMeshProUGUI[] _names;
    [SerializeField] private Image[] _nameSquares;
    [SerializeField] private Color _activeColor;
    [SerializeField] private Color _inactiveColor;

    [Header("Body of the text")] 
    [SerializeField] private Transform _linesParent;

    [Header("Prefabs")] 
    [SerializeField] private DialogueNormalManager _normalLine;
    [SerializeField] private DialogueAnswerManager _answerLine;

    public bool IsRunning => _isRunning;
    private bool _isRunning;
    private Coroutine _coroutine;

    private void OnEnable(){
        if (Instance != null){
            Destroy(Instance.gameObject);
        }

        Instance = this;
    }

    private void Update(){
        if (Input.GetButtonDown("Fire1") && _dialogue != null)
            Next();
    }
    public void StartDialogue(Dialogue dialogue){
        if (dialogue == null){
            EndDialogues();
            return;
        }
        
        if (!_dialogueUiParent.activeInHierarchy)
            _dialogueUiParent.SetActive(true);
        if (_dialogue == null || _dialogue.CharacterName != dialogue.CharacterName){
            ushort id = (ushort) dialogue.Side;
            _names[id].text = dialogue.CharacterName;
            _nameSquares[id].color = _activeColor;
            _nameSquares[id == 0 ? 1 : 0].color = _inactiveColor;
        }

        if (dialogue.ItemEarned != null)
            TimoteePlayer.CurrentPlayer.Inventory.AddItem(dialogue.ItemEarned);
        
        _dialogue = dialogue;

        Write(dialogue);
    }

    private void Write(Dialogue dialogue){
        ResetText();

        StartCoroutine(_dialogue.IsQuestion ? WriteQuestionDialogueCoroutine() : WriteNormalDialogueCoroutine());
    }
    
    private IEnumerator WriteNormalDialogueCoroutine(){
        _isRunning = true;
        var lines = new DialogueNormalManager[4];
        for (int l = 0; l < _dialogue.Lines.Length; l++){
            lines[l] = Instantiate(_normalLine, _linesParent);
        }
        
        for (int l = 0; l < _dialogue.Lines.Length; l++){
            var line = lines[l];
            var text = _dialogue.Lines[l];

            var index = 0;

            while (index < text.Length){
                if (_isRunning) yield return new WaitForSeconds(1 / _writingSpeed);
                index++;
                line.text = text.Substring(0, index);
            }
            
            line.text = text;
        }

        _isRunning = false;
    }

    private IEnumerator WriteQuestionDialogueCoroutine(){
        _isRunning = true;
        IDialogue[] lines = new IDialogue[4];
        for (int l = 0; l < _dialogue.Lines.Length; l++){
            if (_dialogue.IsLineAnswer[l])
                lines[l] = Instantiate(_answerLine, _linesParent);
            else
                lines[l] = Instantiate(_normalLine, _linesParent);
        }
        
        for (int l = 0; l < _dialogue.Lines.Length; l++){
            IDialogue line = lines[l];
            if (_dialogue.IsLineAnswer[l]){
                line.SetText(_dialogue.Lines[l]);
                var nextDialogue = _dialogue.NextDialogue[l];
                ((DialogueAnswerManager)line).OnClick += delegate{ StartDialogue(nextDialogue); };
                
                continue;
            }

            yield return null;
            
            var text = _dialogue.Lines[l];

            var index = 0;

            while (index < text.Length){
                if (_isRunning) yield return new WaitForSeconds(1 / _writingSpeed);
                index++;
                line.SetText(text.Substring(0, index));
            }
            
            line.SetText(text);
        }

        _isRunning = false;
    }

    public void Next(){
        if (_dialogue == null) return;
        if (_isRunning){
            _isRunning = false;
            return;
        }
        
        if (_dialogue.IsQuestion)
            return;

        if (_dialogue.NextDialogue == null || _dialogue.NextDialogue.Length == 0){
            EndDialogues();
            return;
        }
        
        StartDialogue(_dialogue.NextDialogue[0]);
    }

    private void ResetText(){
        foreach (Transform line in _linesParent){
            Destroy(line.gameObject);
        }
    }

    private void EndDialogues(){
        ResetText();
        foreach (var name in _names){
            name.text = "";
        }

        foreach (var square in _nameSquares){
            square.color = Color.clear;
        }
        
        GameManager.StopPause();
        _dialogueUiParent.SetActive(false);
    }
}