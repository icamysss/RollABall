using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DynamicButtonListScript : MonoBehaviour
{
        [Header("Button prefab")]
        [SerializeField] private ButtonScript buttonPrefab; // незачем GameObject указывать 
        
        [Header("Links")]
        [SerializeField] private Transform content;
        [SerializeField] private TMP_Text message;
        
        [Header("List of buttons")]
        [SerializeField] private List<string> buttonsText = new();

        private void Start()
        {
                for (var i = 0; i < buttonsText.Count; i++)
                {
                      var button = Instantiate(buttonPrefab, content);
                      button.SetText($"{buttonsText[i]}");
                      var idx = i;
                      button.GetButton().onClick.AddListener(()=> ButtonClick(idx) );
                }
        }

    private void ButtonClick(int i)
    {
        message.text = $"Нажата кнопка: {buttonsText[i]}";
    }
}