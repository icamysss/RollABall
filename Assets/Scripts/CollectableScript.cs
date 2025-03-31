using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class CollectableScript: MonoBehaviour
{
        [Header("Parameters")]
        [Range(1f, 360f)] [SerializeField] private float rotationSpeed = 70f;
        [Range(1f, 360f)] [SerializeField] private float PlayerSpeedStep = 1f;

        [Header("Events")]
        public UnityEvent OnPlayerEnter;
        
        
        private void Start()
        {
                transform.Rotate(transform.up, Random.Range(0, 180));
        }

        private void Update()
        {
                transform.Rotate(transform.up, rotationSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
                if (other.CompareTag("Player"))
                {
                        AudioManager.instance.Collect();
                        OnPlayerEnter?.Invoke();
                        gameObject.SetActive(false);
                        
                        // если не первая сцена то увеличиваем скорость игрока 
                        if (SceneManager.GetActiveScene().buildIndex != 0)
                        {
                                // получаем скрипт игрока и увеличиваем его скорость
                                other.gameObject.GetComponent<PlayerScript>().IncreaseSpeed(PlayerSpeedStep);
                        }
                }
        }
}