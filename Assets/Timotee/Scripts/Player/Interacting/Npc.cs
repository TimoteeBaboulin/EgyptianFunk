using UnityEngine;

public class Npc : MonoBehaviour, IInteractable
{
    public GameObject GameObject => gameObject;

    public Dialogue _startingDialogue;
    
    public bool Interact(IActor user)
    {
        UIDialogueWriter.Instance.StartDialogue(_startingDialogue);
        return true;
    }
}