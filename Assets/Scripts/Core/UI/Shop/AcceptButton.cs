using System;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{
    public class AcceptButton : UIButton
    {
        private Button _acceptButton;

        public Button ButtonAccept => _acceptButton;

        private void Awake()
        {
            _acceptButton = GetComponent<Button>();
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