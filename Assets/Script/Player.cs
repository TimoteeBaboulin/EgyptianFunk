using Timotee.Scripts.Player;
using UnityEngine;

public class Player : MonoBehaviour{
    [SerializeField] private PlayeringMovement _movementScript;
    [SerializeField] private MouseLook _cameraMovementScript;

    private bool _isPaused = false;

    private void Awake(){
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable(){
        GameManager.OnPause += PauseStateChanged;
    }

    private void OnDisable(){
        GameManager.OnPause -= PauseStateChanged;
    }

    private void PauseStateChanged(bool paused){
        _isPaused = paused;

        if (paused){
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else{
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        _movementScript.IsPaused = paused;
        _cameraMovementScript.IsPaused = paused;
    }
}