using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class TimoteePlayer : MonoBehaviour, IActor{
    public PlayerInventory Inventory => _inventory;
    [SerializeField] private PlayerInventory _inventory = new();

    public Vector3 Position => transform.position;

    [SerializeField] private InteractHitbox _interact;
    [SerializeField] private float _speed;
    
    private CharacterController _controller;
    private Transform _cameraTransform;

    private void Start(){
        _controller = GetComponent<CharacterController>();
        _cameraTransform = Camera.main.transform;
    }

    void Update(){
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            Move();
        if (Input.GetButtonDown("Interact")){
            Debug.Log("E");
            if (!_interact.Interact(this)){
                Debug.Log("No interactable found");
            }
        }
    }

    private void Move(){
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var movement = _cameraTransform.forward * vertical + _cameraTransform.right * horizontal;
        movement.y = 0;
        _controller.Move(movement.normalized * (Time.deltaTime * _speed));

        
    }

    private void Interact(){
        if (_interact == null || _interact.Interactables.Count == 0) return;
        
        _interact.Interactables[0].Interact(this);
    }
}