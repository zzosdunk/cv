using System;
using System.Collections;
using System.Collections.Generic;
using Core.UI;
using UnityEngine;
using UnityEngine.UI;

public class CarouselItem : UIButton
{
    [SerializeField] private Carousel _carouselController;
    [SerializeField] private Sprite _gfxRepresentation;
    private Image _imageField;
    public Sprite GfxRepresentation => _gfxRepresentation;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _imageField = GetComponent<Image>();
        
        _button.onClick.AddListener(OnButtonClick);
        
        ButtonState(true);
    }

    public void SetItem(Sprite referenceImage)
    {
        _gfxRepresentation = referenceImage;
        _imageField.sprite = _gfxRepresentation;
    }
    

    public override void OnButtonClick()
    {
        base.OnButtonClick();
        
        _carouselController.SetMainImage(_gfxRepresentation);  
    }

    public override void ButtonState(bool state)
    {
        base.ButtonState(state);
    }
}
