using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carousel : MonoBehaviour
{
    [SerializeField] private List<Sprite> _currentCarouselCollection = new List<Sprite>();
    [SerializeField] private List<CarouselItem> _carouselItems = new List<CarouselItem>();

    [SerializeField] private Image _mainImage;

    private void Start()
    {
        LoadCarousel();
    }

    public void LoadCarousel()
    {
        for (int i = 0; i < _carouselItems.Count; i++)
        {
            _carouselItems[i].SetItem(_currentCarouselCollection[i]);
        }
        
        SetMainImage(_carouselItems[0].GfxRepresentation);
    }
    
    public void CarouselInit(List<Sprite> sprites)
    {
        _currentCarouselCollection.Clear();
        _currentCarouselCollection = sprites;
    }

    public void SetMainImage(Sprite chosenImage)
    {
        _mainImage.sprite = chosenImage;
    }
}
