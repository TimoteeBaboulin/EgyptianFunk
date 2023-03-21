using UnityEngine;

public class DialogueTester : MonoBehaviour{
    [SerializeField] private Dialogue _dialogue;
    
    private void Start(){
        Debug.Log(UIDialogueWriter.Instance);
        UIDialogueWriter.Instance.StartDialogue(_dialogue);
    }
}