using TMPro;
using UnityEditor.SearchService;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] private TMP_Text timerText;   // Ссылка на текст таймера
    [SerializeField] private TMP_Text gameResult;   // Ссылка на текст результата 
    
    [Header("Parameters")]
    [SerializeField] private float goodTime = 40;  // Время хорошего прохождения
    [SerializeField] private float excellentTime = 25; // Время отличного прохождения, должно быть меньше, чем goodTime
    
    private int seconds = 0;  // Время таймера

    private float timer; // Переменная для отсчета 1 секунды
    
    private void Start()
    {
        seconds = 0 ; 
        timer = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;
     
        if (!(timer >= 1)) return;  // если секунда не прошла 
       
        // секунда прошла, обнуляем счетчик
        timer = 0;   
        // увеличиваем на 1 секунды
        seconds++;
        UpdateTimerDisplay(seconds);
    }

    private void UpdateTimerDisplay(float timeInSeconds)
    {
        // Отображаем время в формате "XX секунд"
        timerText.text = seconds.ToString() + " сек.";
    }


    // оценка результата
    public void EvaluatePerformance()
    {
        //gameResult.text = "Вы прошли уровень за " + seconds + " сек.";
        var i = SceneLoader.GetCurrentLevelIndex().ToString();
        string key = "Level" + i;
        if (seconds < excellentTime)
        {
            gameResult.text = "Отлично! Вы прошли уровень очень быстро.";
           
            PlayerPrefs.SetInt(key, 3);
        }
        else if (seconds < goodTime)
        {
            gameResult.text = "Хорошо! Вы прошли уровень за среднее время.";
            
            PlayerPrefs.SetInt(key, 2);
        }
        else
        {
            gameResult.text = "Можно лучше! Попробуйте пройти уровень быстрее.";
            PlayerPrefs.SetInt(key, 1);
        }
        PlayerPrefs.Save();
    }
    // сброс нашего таймера 
    public void ResetTimer()
    {
        timer = 0;
        seconds = 0;
    }
}