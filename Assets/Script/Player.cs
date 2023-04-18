using System;
using Cinemachine;
using Timotee.Scripts.Player;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private PlayerMovement _movementScript;
    [SerializeField] private MouseLook _cameraMovementScript;
    [SerializeField] private CinemachineVirtualCamera _vcam;

    [SerializeField] private GameObject _pauseMenu;

    [SerializeField] private bool _isPaused = false;

    private void Awake() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Pause();
        }
    }

    public void Pause()
    {
        Debug.Log("Pause");
        if (_isPaused)
        {
            Debug.Log("1");
            GameManager.StopPause();
            Debug.Log("2");
            _pauseMenu.SetActive(false);
        }
        else
        {
            Debug.Log("3");
            GameManager.StartPause();
            Debug.Log("4");
            _pauseMenu.SetActive(true);
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