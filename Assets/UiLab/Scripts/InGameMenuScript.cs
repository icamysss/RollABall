using UnityEngine;

public class InGameMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;

    public void returnTomainMenu()
    {
        Time.timeScale = 1f;
        SceneLoader.LoadMainMenu();
        AudioManager.instance.Click();
    }

    public void loadNextLevel()
    {
        Time.timeScale = 1f;
        SceneLoader.LoadNextLevel();
        AudioManager.instance.Click();
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        changeMenuStatus();
        AudioManager.instance.Click();
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