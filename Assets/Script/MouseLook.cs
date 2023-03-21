using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using Timotee.Scripts.Player;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.XR;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private PlayeringMovement playermovement;
    
    public Transform playerBody;
    public Transform camFocus;
    
    public bool IsPaused;

    void Update() {
        if (IsPaused) return;
        if ( Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f) {
            ChangeRotation();
        }
    } 
    
    private void ChangeRotation() {
        Vector3 camRotation;
        camRotation = camFocus.eulerAngles;
        camRotation.x = 0;
        playerBody.eulerAngles = camRotation;
    }
}
