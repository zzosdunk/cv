using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimStatesControl : MonoBehaviour
{
    public float Accelaration;
    public float Decelaration;
    public float MaximumWalkVelocity = 0.5f;
    public float MaximumRunVelocity = 2f;
    
    private Animator _animator;

    private float _velocityX = 0f;
    private float _velocityZ = 0f;
    private float _currentMaxVelocity;

    private bool _forward, _left, _right, _back, _run;

    private int _velocityXHash;
    private int _velocityZHash;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();

        _velocityXHash = Animator.StringToHash("Velocity X");
        _velocityZHash = Animator.StringToHash("Velocity Z");
    }

    private void Update()
    {
        _forward = Input.GetKey(KeyCode.W);
        _left = Input.GetKey(KeyCode.A);
        _right = Input.GetKey(KeyCode.D);
        _run = Input.GetKey(KeyCode.LeftShift);
        _back = Input.GetKey(KeyCode.S);
        
        _currentMaxVelocity = _run ? MaximumRunVelocity : MaximumWalkVelocity;

        ChangeVelocity();
        LockOrResetVelocity();
        
        _animator.SetFloat(_velocityXHash, _velocityX);
        _animator.SetFloat(_velocityZHash, _velocityZ);
    }

    void ChangeVelocity()
    {
        if (_forward && _velocityZ < _currentMaxVelocity)
            _velocityZ += Time.deltaTime * Accelaration;

        if (_left && _velocityX > -_currentMaxVelocity)
            _velocityX -= Time.deltaTime * Accelaration;

        if (_right && _velocityX < _currentMaxVelocity)
            _velocityX += Time.deltaTime * Accelaration;

        if (_back && _velocityZ > -_currentMaxVelocity)
        {
            _velocityZ -= Time.deltaTime * Accelaration;
        }

        if (!_forward && _velocityZ > 0f)
            _velocityZ -= Time.deltaTime * Decelaration;
        
        if (!_left && _velocityX < 0f)
            _velocityX += Time.deltaTime * Decelaration;
        
        if (!_right && _velocityX > 0f)
        {
            _velocityX -= Time.deltaTime * Decelaration;
        }
        
        if (!_back && _velocityZ < 0f)
        {
            _velocityZ += Time.deltaTime * Decelaration;
        }
    }

    void LockOrResetVelocity()
    {
        // if (!_forward && _velocityZ < 0f && !_back)
        //     _velocityZ = 0f;

        if (_forward && !_run && _velocityZ >= _currentMaxVelocity)
        {
            _velocityZ -= Time.deltaTime * Decelaration;
        }

        if (_back && !_run && _velocityZ <= -_currentMaxVelocity)
        {
            _velocityZ += Time.deltaTime * Decelaration;
        }

        if (_right && !_run && _velocityX >= _currentMaxVelocity)
        {
            _velocityX -= Time.deltaTime * Decelaration;
        }

        if (_left && !_run && _velocityX <= -_currentMaxVelocity)
        {
            _velocityX += Time.deltaTime * Decelaration;
        }

        // if (!_left && !_right && _velocityX != 0f && (_velocityX > -0.05f && _velocityX < 0.05f))
        // {
        //     _velocityX = 0f;
        // }
        //
        // if (_forward && _run && _velocityX > _currentMaxVelocity)
        // {
        //     _velocityZ = _currentMaxVelocity;
        // }
        // else if (_forward && _velocityZ > _currentMaxVelocity)
        // {
        //     _velocityZ -= Time.deltaTime * Decelaration;
        //     if (_velocityZ > _currentMaxVelocity && _velocityZ < (_currentMaxVelocity + 0.05f))
        //     {
        //         _velocityZ = _currentMaxVelocity;
        //     }
        // }
        // else if (_forward && _velocityZ < _currentMaxVelocity && _velocityZ > (_currentMaxVelocity - 0.05f))
        // {
        //     _velocityZ = _currentMaxVelocity;
        // }
    }
}
