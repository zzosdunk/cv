using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(Rigidbody))]
public class TopDownPlayerController : MonoBehaviour
{
    [Header("Movement Settings")] 
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _runningSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private bool _rotateTowards;
    [SerializeField] private bool _isRunning;
    
    private Vector3 _movement;
    private Vector3 _mouseRotation;
    private Rigidbody _rb;

    [SerializeField] private CinemachineVirtualCamera _CMCamera;
    [SerializeField] private Camera _camera;
    
    private Vector3 _previousPosition;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _movement.x = Input.GetAxis("Horizontal");
        _movement.y = Input.GetAxis("Vertical");
        _isRunning = Input.GetKey(KeyCode.LeftShift);

        _mouseRotation = Input.mousePosition;
        
        var targetVector = new Vector3(_movement.x, 0, _movement.y);
        var movementVector = MoveTowardTarget(targetVector);

        if (!_rotateTowards)
        {
            RotateTowardMovementVector(movementVector);
        }
        else
        {
            RotateFromMouseVector();
        }

    }
    
    private void RotateFromMouseVector()
    {
        Ray ray = _camera.ScreenPointToRay(_mouseRotation);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f))
        {
            var target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);
        }
    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        var speed = _movementSpeed * Time.deltaTime;

        speed = _isRunning ? _movementSpeed * Time.deltaTime * _runningSpeed : _movementSpeed * Time.deltaTime;
        // transform.Translate(targetVector * (MovementSpeed * Time.deltaTime)); Demonstrate why this doesn't work
        //transform.Translate(targetVector * (MovementSpeed * Time.deltaTime), Camera.gameObject.transform);

        targetVector = Quaternion.Euler(0, _camera.transform.rotation.eulerAngles.y, 0) * targetVector;
        var targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;
        return targetVector;
    }

    private void RotateTowardMovementVector(Vector3 movementDirection)
    {
        if(movementDirection.magnitude == 0) { return; }
        var rotation = Quaternion.LookRotation(movementDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, _rotationSpeed);
    }
}
