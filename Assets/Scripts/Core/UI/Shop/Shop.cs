using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject _progressInfoPanel;
    [SerializeField] private GameObject _completedStarsPanel;

    public void UnlockShop()
    {
        EnableCompletedPanel();
        EnableShop();
    }

    public void EnableCompletedPanel()
    {
        _progressInfoPanel.SetActive(false);
        _completedStarsPanel.SetActive(true);
    }

    public void EnableShop()
    {
        
    }
}
