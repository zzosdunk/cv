using System;
using System.Collections;
using System.Collections.Generic;
using Core.Interactions;
using Core.Inventory;
using Core.UI;
using UnityEngine;

namespace Core
{
    public class EventManager : MonoBehaviour
    {
        public event Action<InventoryItemData> OnItemsPick;
        public void ItemPick(InventoryItemData _inventoryItem)
        {
            OnItemsPick?.Invoke(_inventoryItem);
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

        public event Action<PanelType> OnPanelOpen;
        public void PanelOpen(PanelType panelTabType)
        {
            OnPanelOpen?.Invoke(panelTabType);
        }

    }
}

