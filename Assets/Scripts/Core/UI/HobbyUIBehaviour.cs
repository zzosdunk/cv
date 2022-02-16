using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using Core.Inventory;
using UnityEngine;
using UnityEngine.UI;

public class HobbyUIBehaviour : MonoBehaviour
{
    [SerializeField] private RectTransform _hobbiesLayout;
    [SerializeField] private GameObject _hobbyDataPrefab;

    private List<InventoryItemData> _currentHobbies = new List<InventoryItemData>();
    private List<GameObject> _instantiatedHobbies = new List<GameObject>();

    private void Awake()
    {
        GameManager.Instance.EventManager.OnItemsPick += NewItemFound;
    }

    void NewItemFound(InventoryItemData hobby)
    {
        if (!_currentHobbies.Contains(hobby))
        {
            _currentHobbies.Add(hobby);
        }

        var newHobby = Instantiate(_hobbyDataPrefab, _hobbiesLayout);
        _instantiatedHobbies.Add(newHobby);
        
        HobbyUI hobbyInfoPanel = newHobby.GetComponent<HobbyUI>();

        hobbyInfoPanel.SetHobbyUIPanel(hobby);
        
        LayoutRebuilder.ForceRebuildLayoutImmediate(_hobbiesLayout);
        
        Debug.Log("we picked a new item");
    }

    void HobbyDataInit(GameObject unlockedHobby)
    {
        Debug.Log(unlockedHobby.name);
        
        var hobbyInfoPanel = unlockedHobby.GetComponent<HobbyUI>();
        Debug.Log(hobbyInfoPanel.name);
        
        // HobbyUI hobbyInfoPanel = unlockedHobby.GetComponent<HobbyUI>();
        // InventoryItem hobbyData = unlockedHobby.GetComponent<InventoryItem>();
        //
        // hobbyInfoPanel.SetHobbyUIPanel(hobbyData.HobbyData);
        //
        // LayoutRebuilder.ForceRebuildLayoutImmediate(_hobbiesLayout);
    }
    
    public void HobbiesState(bool isActive)
    {
        _instantiatedHobbies.ForEach(h => h.SetActive(isActive));
    }
    
    private void OnDisable()
    {
        GameManager.Instance.EventManager.OnItemsPick -= NewItemFound;
    }
}
