using TMPro;
using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
namespace Core.UI.AboutGame
{
    public class AboutGamePanel : MovablePanel
    {
        [SerializeField] private TextMeshProUGUI _decsriptionField;
        [SerializeField, TextArea] private string _description;
        
        private void Awake()
        {
            GameManager.Instance.EventManager.OnPanelOpen += ShowPanel;
        }
        
        protected override void ShowPanel(PanelType panelType)
        {
            base.ShowPanel(panelType);
            
            GameManager.Instance.UIManager.TextCharAnimation(_decsriptionField, _description);
        }
    }
}
