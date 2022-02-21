using System;
using System.Collections;
using System.Collections.Generic;
using Core.Inventory;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private InventoryItemData _hobbyData;
    public InventoryItemData HobbyData => _hobbyData;

    [SerializeField] private GameObject _hidedObj;
    
    private ParticleSystem _itemEffect;

    private void Awake()
    {
        _itemEffect = GetComponent<ParticleSystem>();
    }

    void Start()
    {
        var main = GetComponent<ParticleSystem>().main;
        main.stopAction = ParticleSystemStopAction.Callback;
    }

    public void HideInteractableItem()
    {
        _itemEffect.Play();
    }
    
    void OnParticleSystemStopped()
    {
        _hidedObj.SetActive(false);
    }
    
}
