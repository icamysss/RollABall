using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class WinTimer: MonoBehaviour
    {
        [SerializeField] private TMP_Text timerText; // Ссылка на текстовый элемент UI

        public int seconds = 5;  // Время таймера
        public UnityEvent OnTimerEnd;
        
        private float timer; // Переменная для отсчета 1 секунды
        private void Start()
        {
            seconds = 5 ; 
            timer = 0;
            UpdateTimerDisplay(seconds);
            OnTimerEnd.AddListener(OnTimer);
        }

        private void Update()
        {
            timer += Time.unscaledDeltaTime;
     
            if (!(timer >= 1)) return;  // если секунда не прошла 
       
            // секунда прошла, обнуляем счетчик
            timer = 0;   
            // уменьшаем на 1 секунду
            seconds--;
            
            UpdateTimerDisplay(seconds);
            // проверяем кончилось 5 секунд или нет 
            if (seconds <= 0)
            {
                OnTimerEnd?.Invoke();
            }
        }

        // обновляем время 
        private void UpdateTimerDisplay(int timeInSeconds)
        {
            // Отображаем время 
            timerText.text = seconds.ToString();
        }

        private void OnTimer()
        {
            SceneLoader.LoadNextLevel();
        }
        // старт нашего таймера 
        public void StartTimer()
        {
            timer = 0;
            seconds = 5;
        }
    }
}