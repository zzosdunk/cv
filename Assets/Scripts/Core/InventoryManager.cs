using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Inventory
{
    [System.Serializable]
    public class InventoryItemData
    {
        [SerializeField] private string _itemName;
        [SerializeField, TextArea] private string _itemDescription;
        [SerializeField] private Sprite _itemReferenceGFX;
        
        public string ItemName => _itemName;
        public string ItemDescription => _itemDescription;
        public Sprite ItemReferenceGfx => _itemReferenceGFX;
    }

    public class InventoryManager : MonoBehaviour
    {
        [SerializeField] private List<InventoryItem> _inventory;

        public void CollectItem(InventoryItem collectedItem)
        {
            _inventory.Add(collectedItem);
            
            Debug.Log(CurrentInventory().Count);
        }

        public List<InventoryItem> CurrentInventory()
        {
            return _inventory;
        }
    }
}
