using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using Core.UI;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HeaderButton : MonoBehaviour
{
    [SerializeField] private StaticUIBehaviour _staticUI;

    [SerializeField] private PanelType _panelType;
    //[SerializeField] private  _shop;
    [SerializeField] private Button _button;

    [SerializeField] private MovablePanel _panel;
    
    private bool _tabState;
    
    private void Awake()
    {
        _tabState = true;
        _button.onClick.AddListener(delegate { TabPanelState(_tabState); });
    }

    void TabPanelState(bool state)
    {
        if (_tabState)
        {
            _staticUI.HideAllPanels();
            
            GameManager.Instance.EventManager.PanelOpen(_panelType);

            // _panel.DOKill();
            // _panel.DOFade(1f, 2f).OnComplete(delegate
            // {
            //     if (_shop.IsUnlocked)
            //     {
            //         _shop.ShowCompletedEffect();
            //     }
            // });
        }
        else
        {
            HidePanel();
        }
        
        _tabState = !state;
    }

    public void HidePanel()
    {
        _panel.HidePanel();

        _tabState = true;
    }
}
