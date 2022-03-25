using System;
using System.Collections;
using System.Collections.Generic;
using Core.Audio;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{
    public class UIButton : MonoBehaviour
    {
        [SerializeField] private Sound _soundType;

        private bool _isInteractable;


        public virtual void OnButtonClick()
        {
            Sound sound = _isInteractable ? _soundType : Sound.Error;
            
            GameManager.Instance.AudioManager.PlaySound(sound);
            
            Debug.Log("lol");
        }

        public virtual void ButtonState(bool state)
        {
            _isInteractable = state;
        }
    }
}
