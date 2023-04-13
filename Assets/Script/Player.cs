using System;
using Cinemachine;
using Timotee.Scripts.Player;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private PlayerMovement _movementScript;
    [SerializeField] private MouseLook _cameraMovementScript;
    [SerializeField] private CinemachineVirtualCamera _vcam;

    [SerializeField] private GameObject _pauseMenu;

    private bool _isPaused = false;

    private void Awake() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel")) {
            if (_isPaused)
            {
                GameManager.StopPause();
                _pauseMenu.SetActive(false);
            }
            else
            {
                GameManager.StartPause();
                _pauseMenu.SetActive(true);
            }
        }
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
        _vcam.gameObject.SetActive(!paused);
    }
}