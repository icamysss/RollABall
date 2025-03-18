using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenScript : MonoBehaviour
{
    [SerializeField] private GameObject messagePanel;
    [SerializeField] Slider progressBar;
    private void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneLoader.GetLoadingLevelName());
        asyncLoad.allowSceneActivation = false;
        while (asyncLoad.isDone == false)
        {
            progressBar.value = asyncLoad.progress;
            if (asyncLoad.progress >= 0.9f)
            {
                progressBar.value = 1;
                if (messagePanel.activeSelf == false) messagePanel.SetActive(true);
                if (Input.anyKey)
                {
                    SceneLoader.LoadingComplete();
                    asyncLoad.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }
}
