using System;
using System.Collections;
using System.Collections.Generic;
using Core.Audio;
using Core.Inventory;
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
        [SerializeField] private PlayerManager _playerManager;
        public PlayerManager PlayerManager => _playerManager;
        [SerializeField] private AudioManager _audioManager;
        public AudioManager AudioManager => _audioManager;
        
        private Transform _player;
        private void Awake()
        {
            _instance = this;
        }
    }
}

