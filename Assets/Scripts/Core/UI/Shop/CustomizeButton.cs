using Core.Audio;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI.Shop
{
    public class CustomizeButton : UIButton
    {
        [SerializeField] private Shop _shopController;
    
        [SerializeField] private Image _buttonImage;
    
        [SerializeField] private Image _iconImage;
        [SerializeField] private Sprite _lockedButton;
        [SerializeField] private Sprite _unlockedButton;

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
            ButtonState(state);
        
            if (state)
            {
                _buttonImage.DOColor(_shopController.UnlockedColor, 1f);
                _iconImage.sprite = _unlockedButton;
            }
            else
            {
                _buttonImage.color = _shopController.LockedColor;
                _iconImage.sprite = _lockedButton;
            }
        }

        void ChooseCustomMaterial()
        {
            OnButtonClick();
            
            if (_shopController.IsUnlocked)
            {
                _shopController.PreviewImage.sprite = _previewPlayerCustomization;
            
                _shopController.CustomizationPreview(_customMaterial, CustomizationPart.Trousers);
            }
        }

        public override void OnButtonClick()
        {
            base.OnButtonClick();
        }

        public override void ButtonState(bool state)
        {
            base.ButtonState(state);
        }
    }
}
