using System.Collections;
using System.Collections.Generic;
using Core.Inventory;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private InventoryItemData _hobbyData;
    public InventoryItemData HobbyData => _hobbyData;

    [SerializeField] private GameObject _itemParticleEffect;

    public void HideItem()
    {
        _itemParticleEffect.SetActive(true);
    }
}
