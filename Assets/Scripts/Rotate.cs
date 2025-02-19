using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed = 5;
    private void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) *  Time.deltaTime * speed);
    }
}