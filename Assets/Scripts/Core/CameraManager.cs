using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Core.Interactions;
using UnityEngine;

namespace Core
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private CinemachineFreeLook _virtualCamera;
        [SerializeField] private Transform _player;

        private CameraConfig _cameraSettings;
        
        private void Start()
        {
            GameManager.Instance.EventManager.OnLocationEnter += OnLocationEnter;
            GameManager.Instance.EventManager.OnLocationExit += OnLocationExit;
        }

        #region CameraLogic

        public void FocusCameraOnLocation()
        {
            _virtualCamera.m_Follow = null;
            _virtualCamera.m_LookAt = _cameraSettings.LookAtObject;
            _virtualCamera.transform.parent = _cameraSettings.CameraParent;
            StartCoroutine(MoveCameraToFocusPosition(_cameraSettings.FocusPosition));
        
        }

        public void FocusCameraOnPlayer()
        {
            _virtualCamera.transform.parent = null;
            _virtualCamera.m_Follow = _player;
            _virtualCamera.m_LookAt = _player;
        }

        IEnumerator MoveCameraToFocusPosition(Transform lookAtPosition)
        {
            float timeProg = 0f;
    
            Vector3 startPos = _virtualCamera.transform.position;
            Vector3 endPos = lookAtPosition.transform.position;

            while (timeProg < 3f)
            {
                timeProg += Time.deltaTime;
            
                _virtualCamera.transform.position = Vector3.Lerp(startPos, endPos, timeProg);

                yield return null;
            }
        }

        #endregion

        void OnLocationEnter(CameraConfig locationCameraCfg)
        {
            _cameraSettings = locationCameraCfg;
        }

        void OnLocationExit()
        {
            //reset all camera manager settings
            //hide ui
            FocusCameraOnPlayer();
        }

        private void OnDisable()
        {
            GameManager.Instance.EventManager.OnLocationEnter -= OnLocationEnter;
            GameManager.Instance.EventManager.OnLocationExit -= OnLocationExit;
        }
    }
}

