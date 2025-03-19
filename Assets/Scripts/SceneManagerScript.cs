using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript: MonoBehaviour
{
       // [SerializeField] private int nextSceneIndex = 0;
        
        public void FreezeScene() => Time.timeScale = 0;
        public void UnfreezeScene() => Time.timeScale = 1;

        public void LoadNextScene()
        {
               SceneLoader.LoadNextLevel();
        }
        
        public void ReloadScene()
        {
              SceneLoader.LoadLevel(SceneLoader.GetCurrentLevelIndex());
        }
}