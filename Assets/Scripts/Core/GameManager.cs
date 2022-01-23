using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public static GameManager Instance => _instance;

        [Header("MANAGERS")]
        [SerializeField] private UIManager _uiManager;
        public UIManager UIManager => _uiManager;
        [SerializeField] private CameraManager _cameraManager;
        public CameraManager CameraManager => _cameraManager;
        [SerializeField] private EventManager _eventManager;
        public EventManager EventManager => _eventManager;

        private Transform _player;
        private void Awake()
        {
            _instance = this;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                _cameraManager.FocusCameraOnLocation();
            }
        }
    }
}

