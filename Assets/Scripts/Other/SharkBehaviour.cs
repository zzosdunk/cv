using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SharkBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _target;

    [SerializeField] private Transform _firstIdlePosition;
    [SerializeField] private Transform _secondIdlePosition;

    [SerializeField] private float _movementSpeed;
    
    [SerializeField] private bool _isObjectMoving;

    private Transform _currentLookAt;
    
    private void Update()
    {
        if (_isObjectMoving)
        {
            MoveToTarget();
        }
        else
        {
            MoveToIdlePosition();
        }
    }

    void MoveToTarget()
    {
        transform.DOKill();
        
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _movementSpeed * Time.deltaTime);
        transform.DOLookAt(_target.position, 1f);
        //transform.LookAt(_target);
    }

    void MoveToIdlePosition()
    {
        //transform.DOMove(position, 10f).SetLoops(-1, LoopType.Yoyo);

        transform.position = Vector3.Lerp(_firstIdlePosition.position, _secondIdlePosition.position, Mathf.PingPong(Time.time / (_movementSpeed * 10f), 1));

        if ((transform.position - _secondIdlePosition.position).magnitude < 1f)
        {
            _currentLookAt = _firstIdlePosition;

        }
        if ((transform.position - _firstIdlePosition.position).magnitude < 1f)
        {
            _currentLookAt = _secondIdlePosition;
        }

        transform.DOLookAt(_currentLookAt.position, 1f);
    }

    public void SharkState(bool isActive)
    {
        if (isActive)
        {
            _isObjectMoving = true;
        }
        else
        {
            _isObjectMoving = false;
        }
    }
}
