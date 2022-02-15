using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Interactions
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private bool _isPlayerInteracted;
        public bool isPlayerInteracted => _isPlayerInteracted;

        public delegate void EventHandler(GameObject obj);
        public static event EventHandler OnInteracted;

        public static void Interacted(GameObject obj)
        {
            if (OnInteracted != null)
                OnInteracted.Invoke(obj);
        }

        public float InteractionRadius;

        public KeyCode InteractionKey = KeyCode.E;

        public RaycastHit Hit;

        private Interactable LastInteractable;

        void Update()
        {
            if (Input.GetKeyUp(InteractionKey) && isPlayerInteracted)
            {
                //set all data in camera manager and UI
                GameManager.Instance.CameraManager.FocusCameraOnLocation();
                GameManager.Instance.UIManager.DynamicUiBehaviour.ShowInfoPanel();
            }

            if (Input.GetKeyUp(KeyCode.Escape))
            {
                GameManager.Instance.UIManager.DynamicUiBehaviour.HideInfoPanel();
            }
            
            if (Physics.SphereCast(transform.position, InteractionRadius, -transform.up, out Hit, InteractionRadius))
            {
                if (Hit.collider.GetComponent<Interactable>() && Hit.collider.GetComponent<Interactable>().enabled)
                {
                    LastInteractable = Hit.collider.GetComponentInParent<Interactable>();

                    Hit.collider.GetComponentInParent<Interactable>().Show();

                    if (Input.GetKeyUp(InteractionKey))
                    {
                        Interacted(Hit.collider.gameObject);
                        
                        Debug.Log("interaction is working " + Hit.collider.gameObject.name);

                        Hit.collider.GetComponentInParent<Interactable>().Interaction();
                        
                        LastInteractable.Hide();
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

        public void SetInteractMode(bool isInteracted)
        {
            _isPlayerInteracted = isInteracted;

            if (!isPlayerInteracted)
            {
                GameManager.Instance.UIManager.DynamicUiBehaviour.HideInfoPanel();
            }
        }
    }
}
