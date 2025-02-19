using TMPro;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public int objects;
    
    private Rigidbody rb;
    private int count;

    public TMP_Text Score;
    public TMP_Text Victory;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        Victory.text = "";
        SetText();
    }

    private void SetText()
    {
        Score.text = "Score: " + count.ToString();
        if (count >= objects)
        {
            Victory.text = "Victory!";
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetText();
        }
    }
}