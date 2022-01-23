using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Interactions
{
    public class PlayerInteraction : MonoBehaviour
    {
        public delegate void EventHandler(GameObject obj);
        public static event EventHandler OnInteracted;

        public static void Interacted(GameObject obj)
        {
            if (OnInteracted != null)
                OnInteracted.Invoke(obj);
        }

        public float InteractionRadius;

        public KeyCode InteractionKey = KeyCode.F;

        public RaycastHit Hit;

        private Interactable LastInteractable;

        void Update()
        {
            if (Physics.SphereCast(transform.position, InteractionRadius, transform.forward, out Hit, InteractionRadius))
            {
                if (Hit.collider.GetComponent<Interactable>() && Hit.collider.GetComponent<Interactable>().enabled)
                {
                    LastInteractable = Hit.collider.GetComponentInParent<Interactable>();

                    Hit.collider.GetComponentInParent<Interactable>().Show();

                    if (Input.GetKeyUp(InteractionKey))
                    {
                        Interacted(Hit.collider.gameObject);
                        
                        Debug.Log("interaction is working");

                        // Hit.collider.GetComponentInParent<Interactable>().Interaction();
                        //
                        // LastInteractable.Hide();
                    }
                }
                else
                if (LastInteractable != null)
                    LastInteractable.Hide();
            }
            else
            if (LastInteractable != null)
                LastInteractable.Hide();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, InteractionRadius);
        }
    }
}
