using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Interactions
{
    public class CountryLocation : MonoBehaviour
    {
        [SerializeField] private string _countryName;
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponentInParent<PlayerInteraction>())
            {
                GameManager.Instance.UIManager.DynamicUiBehaviour.ShowNewZonePopUp(_countryName);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponentInParent<PlayerInteraction>())
            {
                GameManager.Instance.UIManager.DynamicUiBehaviour.HideZoneEntryPanel();
            }
        }
    }
}