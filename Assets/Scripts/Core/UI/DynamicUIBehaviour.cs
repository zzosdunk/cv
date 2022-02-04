using System;
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

    [SerializeField] private CanvasGroup _infoPanel;
    [SerializeField] private TextMeshProUGUI _panelTitleField;
    
    [SerializeField] private List<PanelTab> _tabs = new List<PanelTab>();
    [SerializeField] private CanvasGroup _descriptionField;
    [SerializeField] private CanvasGroup _galleryField;
    
    public void ShowNewZonePopUp(string nameOfZone)
    {
        _zoneNamefield.text = nameOfZone;

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
    
    public void ShowInfoPanel()
    {
        _galleryField.alpha = 0f;
        _galleryField.blocksRaycasts = false;
        _descriptionField.blocksRaycasts = true;
        _infoPanel.DOFade(1f, 1f).OnComplete(delegate
        {
            _descriptionField.DOFade(1f, 1f);
        });
    }

    public void HideInfoPanel()
    {
        _infoPanel.DOFade(0f, 1f);
    }

    public void ChangeTab(PanelTab clickedTab)
    {
        _tabs.ForEach(t => t.SetTabState(false));
        clickedTab.SetTabState(true);

        switch (clickedTab.PanelTabType)
        {
            case PanelTabType.Info:
                _galleryField.DOFade(0f, 0.5f).OnComplete(delegate
                {
                    _galleryField.blocksRaycasts = false;
                    _descriptionField.blocksRaycasts = true;
                    _descriptionField.DOFade(1f, 0.5f);
                });
                break;
            case PanelTabType.Gallery:
                _descriptionField.DOFade(0f, 0.5f).OnComplete(delegate
                {
                    _galleryField.blocksRaycasts = true;
                    _descriptionField.blocksRaycasts = false;
                    _galleryField.DOFade(1f, 0.5f);
                });
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
