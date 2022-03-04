using System.Collections;
using System.Collections.Generic;
using Core.UI;
using UnityEngine;

public class StaticUIBehaviour : MonoBehaviour
{
    [SerializeField] private List<HeaderButton> _headerButtons = new List<HeaderButton>();

    private PanelType _currentPanel;
    public PanelType CurrentPanel => _currentPanel;

    public void HideAllPanels()
    {
        _headerButtons.ForEach(p => p.HidePanel());

        _currentPanel = PanelType.None;
    }

    public void SetCurrentPanelType(PanelType clickedPanel)
    {
        _currentPanel = clickedPanel;
    }
}
