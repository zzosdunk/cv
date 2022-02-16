using System.Collections;
using System.Collections.Generic;
using Core.Inventory;
using TMPro;
using UnityEngine;

public class HobbyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _hobbyNameField;
    [SerializeField] private TextMeshProUGUI _hobbyDescriptionField;

    public void SetHobbyUIPanel(InventoryItemData hobbyData)
    {
        _hobbyNameField.text = hobbyData.ItemName;
        _hobbyDescriptionField.text = hobbyData.ItemDescription;
    }
}
