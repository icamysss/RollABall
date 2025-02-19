using TMPro;
using UnityEngine;

public class JumpActivator: MonoBehaviour
{
    [SerializeField] private float JumpForce;
    [SerializeField] private TMP_Text messageText;

    private void Start()
    {
        messageText.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerScript>().SetJumpForce(JumpForce);
            messageText.text = "Прыжок активирован ! Жми пробел !";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        messageText.text = "";
    }
}