using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerScript : MonoBehaviour
{
    [Header("Parameters")]
    [Range(0.1f, 100f)]
    [SerializeField] float speed = 1.0f;
    
    [Range(0.1f, 100f)]
    [SerializeField] float jumpForce = 1.0f;
    
    [Header("Links")]
    [SerializeField] CameraScript cameraControll;

    private Rigidbody rb;
    
    float movementX = 0.0f;
    float movementY = 0.0f;

    [SerializeField] private bool onFloor;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void OnJump(InputValue movementValue)
    {
        if (onFloor) rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnLook(InputValue lookValue)
    {
        float horizontalRotation = lookValue.Get<Vector2>().x;
        cameraControll.rotate(horizontalRotation);
    }
    private void FixedUpdate()
    {
        Vector3 movement = cameraControll.GetDirection(new Vector3(movementX, 0.0f, movementY).normalized);
        rb.AddForce(movement * speed);

        cameraControll.Follow();
    }

    // увеличивает скорость на данное значение
    public void IncreaseSpeed(float amount)
    {
        speed += amount;
    }
    
    // устанавливает силу прыжка
    public void SetJumpForce(float amount)
    {
        jumpForce = amount;
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Floor")) onFloor = true;
    }
    
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Floor")) onFloor = false;
    }
}