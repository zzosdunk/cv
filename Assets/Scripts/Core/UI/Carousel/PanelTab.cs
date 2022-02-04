using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public enum PanelTabType
{
    Info,
    Gallery
}

public class PanelTab : MonoBehaviour
{
    [SerializeField] private PanelTabType _panelTabType;
    public PanelTabType PanelTabType => _panelTabType;

    [SerializeField] private Sprite _activeSprite;
    [SerializeField] private Sprite _disableSprite;
    [SerializeField] private Image _buttonImage;
    [SerializeField] private Image _highlightSymbol;
    [SerializeField] private Button _tabButton;

    private void Awake()
    {
        _tabButton.onClick.AddListener(OnTabClicked);
    }

    void OnTabClicked()
    {
        GameManager.Instance.UIManager.DynamicUiBehaviour.ChangeTab(this);
    }

    public void SetTabState(bool isActive)
    {
        _buttonImage.sprite = isActive ? _activeSprite : _disableSprite;
        _highlightSymbol.gameObject.SetActive(isActive);
    }
    
}
