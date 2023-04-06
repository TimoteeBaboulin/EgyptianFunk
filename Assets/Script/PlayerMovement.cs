using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Cinemachine;
using Timotee.Scripts.Player;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    public CharacterController controller;

    [Header("vitesse déplacemnt")]
    public float speed = 1f;
    public float walk = 6f;
    
    [Header("gravité")]
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [Header("PositionChildPlayerComponent")]
    public Transform playerbodyControl;
    public Vector3 _velocity;
    public bool _isGrounded;

    public bool IsPaused;
    
    private void Start() {
        speed = walk;
    }

    private void Movement() {
        if (IsPaused) return;
        
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (_isGrounded && _velocity.y < 0) _velocity.y = -2f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * (speed * Time.deltaTime));
    }
    
    void Update() {
        Movement();
        speed = walk;
        
        _velocity.y += gravity * Time.deltaTime;
        controller.Move(_velocity * Time.deltaTime);
    }
}