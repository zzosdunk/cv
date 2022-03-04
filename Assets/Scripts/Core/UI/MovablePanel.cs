using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Core.UI
{
    [System.Serializable]
    public enum PanelType
    {
        AboutGame = 1,
        Shop = 2,
        Map = 3,
        None = 4,
        
    }
    
    public class MovablePanel : MonoBehaviour
    {
        [SerializeField] private PanelType _panelType;
        
        [SerializeField] private CanvasGroup _panelCanvas;

        private void Awake()
        {
            GameManager.Instance.EventManager.OnPanelOpen += ShowPanel;
        }

        private void Start()
        {
            HidePanel();
        }

        protected virtual void ShowPanel(PanelType panelType)
        {
            GameManager.Instance.UIManager.StaticUiBehaviour.SetCurrentPanelType(panelType);

            if (_panelType == panelType)
            {
                switch (_panelType)
                {
                    case PanelType.AboutGame:
                        _panelCanvas.blocksRaycasts = true;
                        _panelCanvas.DOFade(1f, 2f);
                        Debug.Log("open info about");
                        break;
                    case PanelType.Shop:
                        _panelCanvas.blocksRaycasts = true;
                        _panelCanvas.DOFade(1f, 2f);
                        
                        break;
                    case PanelType.Map:
                        _panelCanvas.blocksRaycasts = true;
                        _panelCanvas.DOFade(1f, 2f);
                        Debug.Log("open map");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(panelType), panelType, null);
                }
            }

            
            
        }

        public void HidePanel()
        {
            _panelCanvas.DOKill();
            _panelCanvas.DOFade(0f, 1f);
            _panelCanvas.blocksRaycasts = false;
        }
    }
}

