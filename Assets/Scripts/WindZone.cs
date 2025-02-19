using System;
using TMPro;
using UnityEngine;

public class WindZone : MonoBehaviour
{
    [SerializeField] private float windStrength;
    [SerializeField] private TMP_Text windText;

    private void Start()
    {
        windText.text = "";
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * windStrength);
            windText.text = "Дует ветер с силой " + windStrength + " м / с";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        windText.text = "";
    }
}