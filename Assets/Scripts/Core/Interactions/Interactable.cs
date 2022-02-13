using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Interactions
{
    public class Interactable : MonoBehaviour
    {
        public virtual string InteractionMessage { get; }

        public virtual void Show()
        {
            Debug.Log("test");
        }

        public virtual void Hide() { }

        public virtual void Interaction() { }
    }
}

