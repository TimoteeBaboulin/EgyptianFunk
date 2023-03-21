using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

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
