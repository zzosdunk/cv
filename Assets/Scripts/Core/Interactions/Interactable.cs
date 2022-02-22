using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Interactions
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField] private InventoryItem _item;
        [SerializeField] private List<Outline> _outline;

        private bool _isInteracted;
        
        public virtual string InteractionMessage { get; }

        public virtual void Show()
        {
            if (!_isInteracted)
            {
                _outline.ForEach(o => o.enabled = true);
            }
            else
            {
                _outline.ForEach(o => o.enabled = false);
            }
            
        }

        public virtual void Hide()
        {
            _isInteracted = false;
            _outline.ForEach(o => o.enabled = false);
        }

        public virtual void Interaction()
        {
            GameManager.Instance.EventManager.ItemPick(_item.HobbyData);
            _isInteracted = true;
            _outline.ForEach(o => o.enabled = false);
            _item.HideInteractableItem();
        }
    }
}

