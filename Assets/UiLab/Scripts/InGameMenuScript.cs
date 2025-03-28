using UnityEngine;

public class InGameMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;

    public void returnTomainMenu()
    {
        Time.timeScale = 1f;
        SceneLoader.LoadMainMenu();
    }

    public void loadNextLevel()
    {
        Time.timeScale = 1f;
        SceneLoader.LoadNextLevel();
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        changeMenuStatus();
    }
    
    public void quitGame()
    {
        Application.Quit();
    }

    public void changeMenuStatus()
    {
        if (menuPanel.activeSelf == true)
        {
            Time.timeScale = 1.0f;
            menuPanel.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            menuPanel.SetActive(true);
        }
    }
}