using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private StaticUIBehaviour _staticUIBehaviour;
        [SerializeField] private DynamicUIBehaviour _dynamicUIBehaviour;
        
        public StaticUIBehaviour StaticUiBehaviour => _staticUIBehaviour;
        public DynamicUIBehaviour DynamicUiBehaviour => _dynamicUIBehaviour;
    }
}

