using UnityEditor;
using UnityEngine;

namespace UiLab.Scripts
{
    public class Exit : MonoBehaviour
    {
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