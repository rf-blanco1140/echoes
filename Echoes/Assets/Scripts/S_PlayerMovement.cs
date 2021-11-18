using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerMovement : MonoBehaviour
{
    enum MovementSpeed { Sneak, Walk, Run};
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _sneakSpeed;
    [SerializeField] private float _runSpeed;
    private float _movementSpeed;
    private bool _isRunning;

    private Vector3 _movementVector;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _movementSpeed = _walkSpeed;
        _isRunning = false;
    }

    private void Update()
    {
        _movementVector.x = Input.GetAxis("Horizontal");
        _movementVector.z = Input.GetAxis("Vertical");
        
        if(Input.GetKeyDown(KeyCode.K))
        {
            SetMovementSpeed(MovementSpeed.Sneak);
        }
        else if(Input.GetKeyDown(KeyCode.L))
        {
            SetMovementSpeed(MovementSpeed.Run);
            _isRunning = true;
        }
        
        if(Input.GetKeyUp(KeyCode.L) || Input.GetKeyUp(KeyCode.K))
        {
            SetMovementSpeed(MovementSpeed.Walk);
            _isRunning = false;
        }
    }

    private void FixedUpdate()
    {
        if(_movementVector.x != 0 || _movementVector.z != 0)
        {
            MovePlayerCharacter();
        }
    }

    private void MovePlayerCharacter()
    {
        _rb.MovePosition(_rb.position + _movementVector * _movementSpeed * Time.deltaTime);
    }

    private void SetMovementSpeed(MovementSpeed pSpeed)
    {
        switch (pSpeed)
        {
            case MovementSpeed.Sneak:
                _movementSpeed = _sneakSpeed;
                break;
            case MovementSpeed.Run:
                _movementSpeed = _runSpeed;
                break;
            case MovementSpeed.Walk:
                _movementSpeed = _walkSpeed;
                break;
        }
    }

    public bool IsRunning()
    {
        return _isRunning;
    }
}
