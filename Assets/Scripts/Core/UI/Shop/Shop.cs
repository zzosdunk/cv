using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private GameObject _progressInfoPanel;
    [SerializeField] private GameObject _completedStarsPanel;

    [SerializeField] private Animator _starsCompletedAnim;

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
        
        _starsCompletedAnim.Play("stars_completed");
    }

    public void EnableShop()
    {
        
    }
}
