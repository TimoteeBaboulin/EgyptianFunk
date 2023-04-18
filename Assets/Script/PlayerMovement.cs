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


    [SerializeField] private Camera _camera;
    private Animator _animator;

    public bool IsPaused;
    
    private void OnEnable()
    {
        _animator = GetComponentInChildren<Animator>();
        speed = walk;
        GameManager.OnPause += AnimatorPause;
    }

    private void OnDisable()
    {
        GameManager.OnPause -= AnimatorPause;
    }

    private void AnimatorPause(bool pause)
    {
        _animator.speed = pause == true ? 0 : 1; 
    }

    private void Movement() {
        if (IsPaused) return;
        
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (_isGrounded && _velocity.y < 0) _velocity.y = -2f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        _animator.SetFloat("Movement", Math.Abs(x) + Math.Abs(z));
        
        Vector3 move = _camera.transform.right * x + _camera.transform.forward * z;
        move.y = 0;
        controller.Move(move * (speed * Time.deltaTime));
        transform.LookAt(transform.position + move);
    }
    
    void Update() {
        Movement();
        speed = walk;
        
        _velocity.y += gravity * Time.deltaTime;
        controller.Move(_velocity * Time.deltaTime);
        
    }
}