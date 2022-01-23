using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Interactions
{
    [System.Serializable]
    public class LocationData
    {
        [SerializeField] private int _id;
        [SerializeField] private string _name;

        public int Id => _id;
        public string Name => _name;
    }

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

    [System.Serializable]
    public class LocationUIInfo
    {
        [SerializeField , TextArea] private List<string> _slidesContent;
        public List<string> SlidesContent => _slidesContent;
    }
    public class Location : Interactable
    {
        [SerializeField] private LocationData _locationData;
        public LocationData LocationData => _locationData;

        [SerializeField] private CameraConfig _cameraConfig;
        [SerializeField] private LocationUIInfo _uiInfo;
        
        public override string InteractionMessage { 
            get
            {
                string txt = "Press <b>F</b> to Pick up the key";
                return txt;
            } 
        }

        public override void Show()
        {
            base.Show();
        }
        
        public override void Interaction()
        {
            base.Interaction();
        }

        public override void Hide()
        {
            base.Hide();
        }
        
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.GetComponentInParent<PlayerInteraction>())
            {
                GameManager.Instance.EventManager.LocationEnter(_cameraConfig);
                //show UI
            }
        }
        
        private void OnTriggerExit(Collider collision)
        {
            if (collision.GetComponentInParent<PlayerInteraction>())
            {
                GameManager.Instance.EventManager.LocationExit();
                //hide UI
            }
        }
    }
}

