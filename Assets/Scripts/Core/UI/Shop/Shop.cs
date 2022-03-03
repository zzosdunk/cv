using System;
using System.Collections;
using System.Collections.Generic;
using Core.UI;
using UnityEngine;

namespace Core.UI.Dynamic
{


    public class Shop : MovablePanel
    {
        [SerializeField] private GameObject _shopPanel;
        [SerializeField] private GameObject _progressInfoPanel;
        [SerializeField] private GameObject _completedStarsPanel;

        [SerializeField] private Animator _starsCompletedAnim;

        private bool _isUnlocked;
        public bool IsUnlocked => _isUnlocked;

        private void Awake()
        {

        }

        private void Start()
        {
            // _shopPanel.SetActive(false);
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
        }
    }
}