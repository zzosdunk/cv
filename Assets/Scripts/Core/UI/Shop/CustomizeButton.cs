using System;
using System.Collections;
using System.Collections.Generic;
using Core.UI.Dynamic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CustomizeButton : MonoBehaviour
{
    [SerializeField] private Shop _shopController;
    
    [SerializeField] private Image _buttonImage;
    
    [SerializeField] private Image _iconImage;
    [SerializeField] private Sprite _lockedButton;
    [SerializeField] private Sprite _unlockedButton;
    [SerializeField] private Color _lockedButtonColor;
    [SerializeField] private Color _unlockedButtonColor;

    [SerializeField] private Image _previewImage;
    [SerializeField] private Sprite _previewPlayerCustomization;

    [SerializeField] private Material _customMaterial;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        
        _button.onClick.AddListener(ChooseCustomMaterial);
    }

    private void Start()
    {
        ChangeButtonIcon(false);
    }

    public void ChangeButtonIcon(bool state)
    {
        _button.enabled = state;
        
        if (state)
        {
            _buttonImage.DOColor(_unlockedButtonColor, 1f);
            _iconImage.sprite = _unlockedButton;
        }
        else
        {
            _buttonImage.color = _lockedButtonColor;
            _iconImage.sprite = _lockedButton;
        }
    }

    void ChooseCustomMaterial()
    {
        if (_shopController.IsUnlocked)
        {
            _previewImage.sprite = _previewPlayerCustomization;
            
            _shopController.CustomizationPreview(_customMaterial, CustomizationPart.Trousers);
        }
    }
}
