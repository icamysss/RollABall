using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderMb : MonoBehaviour
{
    [SerializeField] private string mainMenu;
    [SerializeField] private string loadingScreen;
    [SerializeField] private List<string> levels = new();

    private int currentLevelIndex = -1;
    private int loadingLevelIndex = -1;
    int highestLvlIndex = 0;

    private void Awake()
    {
        highestLvlIndex = PlayerPrefs.GetInt("HighestLvlIndex", 0);
        currentLevelIndex = -1;
        loadingLevelIndex = -1;
        if (SceneLoader.SetReference(this))
        {
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int GetHighestLvlIndex()
    {
        return highestLvlIndex;
    }

    public void LoadMainMenu()
    {
        currentLevelIndex = -1;
        loadingLevelIndex = -1;
        SceneManager.LoadScene(loadingScreen);
    }

    public void LoadLevel(int index)
    {
        if (index >= levels.Count) return;
        currentLevelIndex = index;
        loadingLevelIndex = index;
        SceneManager.LoadScene(loadingScreen);
    }

    public void LoadLevel(string name)
    {
        for (int i = 0; i < levels.Count; i++)
        {
            if (levels[i] == name)
            {
                currentLevelIndex = i;
                loadingLevelIndex = i;
            }
            SceneManager.LoadScene(loadingScreen);
        }
    }

    public void LoadNextLevel()
    {
        if (currentLevelIndex + 1 >= levels.Count) LoadMainMenu();
        else
        {
            loadingLevelIndex = currentLevelIndex+1;
            LoadLevel(loadingScreen);
        }
    }
    
    public int GetLevelsCount() {return levels.Count;}

    public string GetLoadingLevelName()
    {
        if (loadingLevelIndex == -1) return mainMenu;
        if (loadingLevelIndex < -1 || loadingLevelIndex >= levels.Count) return null;
        return levels[loadingLevelIndex];
    }

    public void LoadingComplete()
    {
        currentLevelIndex = loadingLevelIndex;

        if (currentLevelIndex > highestLvlIndex)
        {
            highestLvlIndex = currentLevelIndex;
            PlayerPrefs.SetInt("HighestLvlIndex", highestLvlIndex);
        }
    }
}