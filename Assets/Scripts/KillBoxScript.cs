using System;
using UnityEngine;
using UnityEngine.Events;

public class KillBoxScript: MonoBehaviour
{
        public UnityEvent OnPlayerEnter;

        private void OnTriggerEnter(Collider other)
        {
                if (other.CompareTag("Player"))
                {
                        OnPlayerEnter?.Invoke();
                        AudioManager.instance.Lose();
                }
        }
}