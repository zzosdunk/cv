using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarouselItem : MonoBehaviour
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
        
        _button.onClick.AddListener(OnClicked);
    }

    public void SetItem(Sprite referenceImage)
    {
        _gfxRepresentation = referenceImage;
        _imageField.sprite = _gfxRepresentation;
    }

    void OnClicked()
    {
        _carouselController.SetMainImage(_gfxRepresentation);  
    }
}
