﻿using System;
using System.Collections;
using System.Collections.Generic;
using Core.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI.Dynamic
{
    [System.Serializable]
    public enum CustomizationPart
    {
        Trousers = 1,
        
    }
    
    public class Shop : MovablePanel
    {
        [SerializeField] private GameObject _shopPanel;
        [SerializeField] private GameObject _progressInfoPanel;
        [SerializeField] private GameObject _completedStarsPanel;

        [SerializeField] private Animator _starsCompletedAnim;

        [SerializeField] private List<CustomizeButton> _customizeButtons = new List<CustomizeButton>();

        [SerializeField] private Button _applyCustomizationChangesButton;
        
        private bool _isUnlocked;
        public bool IsUnlocked => _isUnlocked;

        private Material _currentTrousersMaterial;
        
        private void Awake()
        {
            GameManager.Instance.EventManager.OnPanelOpen += ShowPanel;
            
            _applyCustomizationChangesButton.onClick.AddListener(ApplyCustomization);
        }

        private void Start()
        {
            // _shopPanel.SetActive(false);
        }

        protected override void ShowPanel(PanelType panelType)
        {
            base.ShowPanel(panelType);

            if (_isUnlocked)
            {
                ShowCompletedEffect();
            }
            
            Debug.Log("test");
        }

        public void UnlockShop()
        {
            EnableCompletedPanel();
            EnableShop();
        }

        public void EnableCompletedPanel()
        {
            _progressInfoPanel.SetActive(false);
            _completedStarsPanel.SetActive(true);

            _isUnlocked = true;

        }

        public void EnableShop()
        {

        }

        public void ShowCompletedEffect()
        {
            _starsCompletedAnim.Play("stars_completed");
            
            _customizeButtons.ForEach(cb => cb.ChangeButtonIcon(true));
        }

        public void CustomizationPreview(Material customizationMaterial, CustomizationPart part)
        {
            switch (part)
            {
                case CustomizationPart.Trousers:
                    _currentTrousersMaterial = customizationMaterial;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(part), part, null);
            }
        }

        void ApplyCustomization()
        {
            if (_currentTrousersMaterial != null)
            {
                GameManager.Instance.PlayerManager.SetNewMaterial(_currentTrousersMaterial);
            }
        }
        
        private void OnDisable()
        {
            GameManager.Instance.EventManager.OnPanelOpen -= ShowPanel;
        }
    }
}