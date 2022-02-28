using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using Core.Inventory;
using UnityEngine;

public class StarsHolder : MonoBehaviour
{
    [SerializeField] private Shop _shopController;
    
    [SerializeField] private List<StarBehaviour> _stars;
    private int _currentStarIndex;
    
    
    private void Awake()
    {
        _currentStarIndex = 0;

        GameManager.Instance.EventManager.OnItemsPick += SetStarActive;
    }

    public void SetStarActive(InventoryItemData _itemCollected)
    {
        _stars[_currentStarIndex].SetStarState(true);

        if (_currentStarIndex < _stars.Count - 1)
        {
            _currentStarIndex++;
        }
        else
        {
            _shopController.UnlockShop();
        }
        
    }
}
