using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectorScript : MonoBehaviour
{
    [SerializeField] private ButtonScript buttonPrefab;
    [SerializeField] private Transform content;

    private Button btn;

    private void Start()
    {
        btn  = GetComponent<Button>();
        if (btn == null) return;
        btn.onClick.AddListener(AudioManager.instance.Click);
    }

    public void BuildLevelSelector()
    {
        int buttonCount = SceneLoader.GetLevelsCount();
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < buttonCount; i++)
        {
            var button = Instantiate(buttonPrefab, content);
            button.SetText((i+1).ToString());
            var k = "Level" + i;
            button.Stars = PlayerPrefs.GetInt(k);;
            var index = i;
            button.GetButton().onClick.AddListener(() => SceneLoader.LoadLevel(index));
            
            if (index > SceneLoader.GetHighestLvlIndex())
                button.GetButton().interactable = false;
        }
    }
}