using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private Vector3 eulers = new Vector3(15, 30, 45) ;
    
    public float speed = 5;
    private void Update()
    {
        transform.Rotate(eulers *  Time.deltaTime * speed);
    }
}