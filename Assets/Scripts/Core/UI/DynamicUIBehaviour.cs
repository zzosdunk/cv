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
    [Header("Zone Pop-Up")]
    [SerializeField] private Image _zoneEntryPopUpImageLeft;
    [SerializeField] private Image _zoneEntryPopUpImageRight;
    [SerializeField] private TextMeshProUGUI _zoneNamefield;

    [Header("Location Info")]
    [SerializeField] private CanvasGroup _infoPanel;
    [SerializeField] private TextMeshProUGUI _panelTitleField;
    [SerializeField] private TextMeshProUGUI _descriptionTextField;
    [SerializeField] private List<PanelTab> _tabs = new List<PanelTab>();
    [SerializeField] private PanelTab _defaultTab;
    [SerializeField] private CanvasGroup _descriptionField;
    [SerializeField] private CanvasGroup _galleryField;
    [SerializeField] private Carousel _carouselController;
    [SerializeField] private HobbyUIBehaviour _hobbyUI;

    [Header("Interaction")] 
    [SerializeField] private CanvasGroup _interactionPanel;
    [SerializeField] private TextMeshProUGUI _interactionMessage;
    [SerializeField] private RectTransform _interactionPanelRect;
    [SerializeField] private RectTransform _activeRectPos;
    [SerializeField] private RectTransform _disabledRectPos;
    
    [Header("Player Reset")]
    [SerializeField] private CanvasGroup _resetPlayerScreen;
    
    [SerializeField] private RectTransform _layoutToRebuild;
    
    
    
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
        if (!_uiData.IsUniqueLocation)
        {
            _hobbyUI.HobbiesState(false);
        }
        else
        {
            _hobbyUI.HobbiesState(true);
        }
        
        _panelTitleField.text = _uiData.locationName;
        _descriptionTextField.text = _uiData.description;
        
        _carouselController.CarouselInit(_uiData.gallerySprites);
        
        LayoutRebuilder.ForceRebuildLayoutImmediate(_layoutToRebuild);
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

    #region Interaction

    public void InteractionState(bool state)
    {
        if (state)
        {
            _interactionPanelRect.DOKill();
            _interactionPanelRect.DOMove(_activeRectPos.position, 1f);
            _interactionPanel.DOFade(1f, 0.75f);
        }
        else
        {
            _interactionPanelRect.DOKill();
            _interactionPanelRect.DOMove(_disabledRectPos.position, 1f);
            _interactionPanel.DOFade(0f, 0.25f);
        }
    }

    public void ResetPlayer(SpawnPositionLocation positionToSpawn) {
        _resetPlayerScreen.DOFade(1f, 2f).OnComplete(delegate
        {
            GameManager.Instance.PlayerManager.SetPlayerPosition(positionToSpawn);
             _resetPlayerScreen.DOFade(0f, 1f);
        });

    }

    public void SetInteractionMessage(string locationName)
    {
        _interactionMessage.text = "Press E to see info about " + locationName;
        
        InteractionState(true);
    }
    #endregion
    
    private void OnDestroy()
    {
        GameManager.Instance.EventManager.OnLocationEnter -= UIDataInit;
    }
}
