using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Interactions
{
    [System.Serializable]
    public class CameraConfig
    {
        [SerializeField] private Transform _lookAtObject;
        [SerializeField] private Transform _focusPosition;
        [SerializeField] private Transform _cameraParent;
        
        public Transform LookAtObject => _lookAtObject;
        public Transform FocusPosition => _focusPosition;
        public Transform CameraParent => _cameraParent;
    }
    
    public class Location : MonoBehaviour
    {
        [SerializeField] private CameraConfig _cameraConfig;
        [SerializeField] private UIDataConfig _uiInfo;

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.GetComponentInParent<PlayerInteraction>())
            {
                collision.GetComponentInParent<PlayerInteraction>().SetInteractMode(true);
                GameManager.Instance.EventManager.LocationEnter(_cameraConfig, _uiInfo);
            }
        }
        
        private void OnTriggerExit(Collider collision)
        {
            if (collision.GetComponentInParent<PlayerInteraction>())
            {
                collision.GetComponentInParent<PlayerInteraction>().SetInteractMode(false);
                GameManager.Instance.EventManager.LocationExit();
            }
        }
    }
}

