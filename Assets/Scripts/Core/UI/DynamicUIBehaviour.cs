using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DynamicUIBehaviour : MonoBehaviour
{
    [SerializeField] private Image _zoneEntryPopUpImageLeft;
    [SerializeField] private Image _zoneEntryPopUpImageRight;
    [SerializeField] private TextMeshProUGUI _zoneNamefield;
    
    public void ShowNewZonePopUp(string nameOfZone)
    {
        _zoneNamefield.text = nameOfZone;
        // _zoneNamefield.gameObject.SetActive(true);
        //
        // _zoneEntryPopUpImage.DOFillAmount(1f, 1f).OnComplete(delegate
        // {
        //     Debug.Log("hide after 3 seconds");
        // });
        
        CountryPopUpSequnce();
    }

    void CountryPopUpSequnce()
    {
        Sequence countryPopUp = DOTween.Sequence();

        _zoneEntryPopUpImageRight.DOFillAmount(1f, 1f);
        countryPopUp.Append(_zoneEntryPopUpImageLeft.DOFillAmount(1f, 1f).OnComplete(delegate
        {
            countryPopUp.Append(_zoneNamefield.DOFade(1f, 1f)); 
        }));
        
        countryPopUp.AppendInterval(5f);
        countryPopUp.Append(_zoneNamefield.DOFade(0f, 0.5f));
        countryPopUp.Append(_zoneEntryPopUpImageRight.DOFillAmount(0, 0));
        countryPopUp.Append(_zoneEntryPopUpImageLeft.DOFillAmount(0, 0));
    }
    
    public void HideZoneEntryPanel()
    {
        _zoneNamefield.DOFade(0f, 0f);
        _zoneEntryPopUpImageLeft.DOFillAmount(0, 0);
        _zoneEntryPopUpImageRight.DOFillAmount(0, 0);
    }
    
    public void EnableInfoPanel()
    {
            
    }

    public void DisableInfoPanel()
    {
            
    }

    public void ShowDataInfoPanel()
    {
            
    }
}
