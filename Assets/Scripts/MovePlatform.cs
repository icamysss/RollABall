using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 endPosition = Vector3.down; // Конечная позиция платформы 
    public float speed = 2f;    // Скорость движения платформы

    private Vector3 startPosition; // Начальная позиция платформы
    private bool movingToEnd = true; // Флаг для определения направления движения

    private Vector3 targetPosition;
    private void Start()
    {
        startPosition = transform.position; // Запоминаем начальную позицию
    }

    public void Update()
    {
        // Определяем целевую позицию в зависимости от направления
        if (movingToEnd)
        {
            targetPosition = startPosition;
        }
        else
        {
            targetPosition = endPosition;
        }
        // Двигаем платформу к целевой позиции
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Если платформа достигла целевой позиции, меняем направление
        if (transform.position == targetPosition)
        {
            movingToEnd = !movingToEnd; // Меняем направление
        }
    }
}