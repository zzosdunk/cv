using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarBehaviour : MonoBehaviour
{
    [SerializeField] private Image _starImage;
    [SerializeField] private Sprite _disabledStar;
    [SerializeField] private Sprite _activeStar;


    public void SetStarState(bool starState)
    {
        _starImage.sprite = starState ? _activeStar : _disabledStar;
    }

    public void StarPartcile()
    {
        //run this when open for the first time shop after all items colletced
    }
}
