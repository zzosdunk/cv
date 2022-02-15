using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using Core.Interactions;
using Core.UI;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class UIDataConfig
{
    [SerializeField] private string _locationName;
    [SerializeField, TextArea] private string _description;
    [SerializeField] private List<Sprite> _gallerySprites;
    [SerializeField] private bool _isUniqueLocation;

    public string locationName => _locationName;
    public string description => _description;
    public List<Sprite> gallerySprites => _gallerySprites;
    public bool IsUniqueLocation => _isUniqueLocation;
}

public class DynamicUIBehaviour : MonoBehaviour
{
    [SerializeField] private Image _zoneEntryPopUpImageLeft;
    [SerializeField] private Image _zoneEntryPopUpImageRight;
    [SerializeField] private TextMeshProUGUI _zoneNamefield;

    [SerializeField] private CanvasGroup _infoPanel;
    [SerializeField] private TextMeshProUGUI _panelTitleField;
    [SerializeField] private TextMeshProUGUI _descriptionTextField;
    
    [SerializeField] private List<PanelTab> _tabs = new List<PanelTab>();
    [SerializeField] private PanelTab _defaultTab;
    [SerializeField] private CanvasGroup _descriptionField;
    [SerializeField] private CanvasGroup _galleryField;

    [SerializeField] private Carousel _carouselController;
    
    private UIDataConfig _uiData;

    private void Awake()
    {
        GameManager.Instance.EventManager.OnLocationEnter += UIDataInit;
    }

    #region Inits

    void UIDataInit(CameraConfig _cameraConfig, UIDataConfig _uiDataConfig)
    {
        _uiData = _uiDataConfig;
        
        InfoPanelInit();
    }

    void InfoPanelInit()
    {
        _panelTitleField.text = _uiData.locationName;
        _descriptionTextField.text = _uiData.description;
        
        _carouselController.CarouselInit(_uiData.gallerySprites);
    }

    #endregion
    

    #region LocationEnterNotification

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

    #endregion
   
    
    public void ShowInfoPanel()
    {
        _galleryField.alpha = 0f;
        _galleryField.blocksRaycasts = false;
        _descriptionField.blocksRaycasts = true;
        _infoPanel.DOFade(1f, 1f).OnComplete(delegate
        {
            _descriptionField.DOFade(1f, 1f);
        });
        
        ChangeTab(_defaultTab);
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
                _galleryField.alpha = 0f;
                _galleryField.blocksRaycasts = false;
                _descriptionField.blocksRaycasts = true;
                _descriptionField.DOFade(1f, 0.5f);
                break;
            case PanelTabType.Gallery:
                _carouselController.LoadCarousel();
                _descriptionField.alpha = 0f;
                _galleryField.blocksRaycasts = true;
                _descriptionField.blocksRaycasts = false;
                _galleryField.DOFade(1f, 0.5f);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void OnDestroy()
    {
        GameManager.Instance.EventManager.OnLocationEnter -= UIDataInit;
    }
}
