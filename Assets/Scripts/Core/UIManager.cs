using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Core
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private StaticUIBehaviour _staticUIBehaviour;
        [SerializeField] private DynamicUIBehaviour _dynamicUIBehaviour;

        [SerializeField] private float _charAnimSpeed;
        
        public StaticUIBehaviour StaticUiBehaviour => _staticUIBehaviour;
        public DynamicUIBehaviour DynamicUiBehaviour => _dynamicUIBehaviour;

        public void TextCharAnimation(TextMeshProUGUI textField, string text)
        {
            StopAllCoroutines();
            StartCoroutine(TypeSentence(textField, text));
        }

        IEnumerator TypeSentence(TextMeshProUGUI textField, string text)
        {
            textField.text = "";
            foreach (var letter in text.ToCharArray())
            {
                textField.text += letter;
                yield return null;
            }
        }
    }
}

