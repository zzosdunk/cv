using System;
using System.Collections;
using System.Collections.Generic;
using Core.Interactions;
using UnityEngine;

namespace Core
{
    public class EventManager : MonoBehaviour
    {
        public event Action OnItemsPick;
        public void ItemPick()
        {
            OnItemsPick?.Invoke();
        }

        public event Action<CameraConfig, UIDataConfig> OnLocationEnter;
        public void LocationEnter(CameraConfig locationData, UIDataConfig infoData)
        {
            OnLocationEnter?.Invoke(locationData, infoData);
        }

        public event Action OnLocationExit;
        public void LocationExit()
        {
            OnLocationExit?.Invoke();
        }

        public event Action<UIDataConfig> OnLocationEnterUI;
        public void LocationEnterUI(UIDataConfig infoData)
        {
            OnLocationEnterUI?.Invoke(infoData);
        }
        
    }
}

