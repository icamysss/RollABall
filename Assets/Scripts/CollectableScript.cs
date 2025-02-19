using System;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class CollectableScript: MonoBehaviour
{
        [Header("Parameters")]
        [Range(1f, 360f)] [SerializeField] private float rotationSpeed = 70f;

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
                        OnPlayerEnter?.Invoke();
                        gameObject.SetActive(false);
                }
        }
}