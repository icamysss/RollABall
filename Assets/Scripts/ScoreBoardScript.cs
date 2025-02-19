using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.FindObjectsSortMode;

public class ScoreBoardScript : MonoBehaviour
{
    [Header("References")] [SerializeField] private TMP_Text scoreText;

    [Header("Events")] public UnityEvent OnCollectAll;

    private int collectablesCount = 0;
    private int collected = 0;

    private void Start()
    {
        CollectableScript[] collectables = FindObjectsByType<CollectableScript>(None);
        collectablesCount = collectables.Length;
        foreach (var collectable in collectables)
        {
            collectable.OnPlayerEnter.AddListener(OnCollect);
            updateScoreText(collected, collectablesCount);
        }
    }

    private void OnCollect()
    {
        if (collected >= collectablesCount) return;
        collected++;
        updateScoreText(collected, collectablesCount);
        
        if (collected >= collectablesCount) OnCollectAll?.Invoke();
    }


    private void updateScoreText(int collected, int collectablesCount)
    {
        scoreText.text = "Объектов собрано " + collected.ToString() + " / " + collectablesCount.ToString();
    }
}