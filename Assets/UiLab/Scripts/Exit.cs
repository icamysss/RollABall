using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace UiLab.Scripts
{
    public class Exit : MonoBehaviour
    {
        private Button btn;

        private void Start()
        {
            if (btn == null) btn = GetComponent<Button>();
            if (btn == null) return;
            btn.onClick.AddListener(AudioManager.instance.Click);
        }

        public void ExitGame()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else 
            Application.Quit();
#endif
        }
    }
}