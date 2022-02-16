using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Interactions
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField] private InventoryItem _item;
        [SerializeField] private List<Outline> _outline;
        
        public virtual string InteractionMessage { get; }

        public virtual void Show()
        {
            _outline.ForEach(o => o.enabled = true);
        }

        public virtual void Hide()
        {
            _outline.ForEach(o => o.enabled = false);
        }

        public virtual void Interaction()
        {
            GameManager.Instance.EventManager.ItemPick(_item.HobbyData);
        }
    }
}

