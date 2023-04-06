using Timotee.Scripts.Player;
using UnityEngine;

public class DialogueTester : MonoBehaviour{
    [SerializeField] private Dialogue _dialogue;
    
    [ContextMenu("Start Dialogue")]
    private void StartDialogue(){
        UIDialogueWriter.Instance.StartDialogue(_dialogue);
        GameManager.StartPause();
    }

    
}