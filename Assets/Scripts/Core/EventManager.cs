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

        public event Action<CameraConfig> OnLocationEnter;
        public void LocationEnter(CameraConfig locationData)
        {
            OnLocationEnter?.Invoke(locationData);
        }

        public event Action OnLocationExit;
        public void LocationExit()
        {
            OnLocationExit?.Invoke();
        }
    }
}

