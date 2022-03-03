using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticUIBehaviour : MonoBehaviour
{
    [SerializeField] private List<HeaderButton> _headerButtons = new List<HeaderButton>();

    public void HideAllPanels()
    {
        _headerButtons.ForEach(p => p.HidePanel());
    }
}
