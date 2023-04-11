using UnityEngine;

[CreateAssetMenu(menuName = "Create Dialogue", fileName = "Dialogue", order = 0)]
public class Dialogue : ScriptableObject {
    public Item ItemEarned;
    public bool IsQuestion;

    public string CharacterName;
    public DialogueSide Side;

    public string[] Lines;
    public bool[] IsLineAnswer;

    public Dialogue[] NextDialogue;
    public CharacterAudioProfile CharacterAudioProfile;
}

public enum DialogueSide{
    Left = 0,
    Right = 1
}