using Unity.VisualScripting;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    private Vector2 direction;
    private float speed;
    private GameManager gameManager;
    private Camera mainCamera;
    private Bounds movementBounds;

    public void Initialize(GameManager manager, float currentSpeed, Bounds bounds)
    {
        gameManager = manager;
        speed = currentSpeed;
        mainCamera = Camera.main;
        direction = Random.insideUnitCircle.normalized;
        movementBounds = bounds;
    }

    void Update()
    {
        Move();
        CheckBoundaries();
    }

    void CheckBoundaries()
    {
        bool changedDirection = false;
        Vector3 newPosition = transform.position;
        Vector2 newDirection = direction;

        // Проверка по X
        if (transform.position.x <= movementBounds.min.x + 0.2f ||
            transform.position.x >= movementBounds.max.x - 0.2f)
        {
            newDirection.x *= -1;
            changedDirection = true;
            newPosition.x = Mathf.Clamp(newPosition.x,
                movementBounds.min.x + 0.2f,
                movementBounds.max.x - 0.2f);
        }

        // Проверка по Y
        if (transform.position.y <= movementBounds.min.y + 0.2f ||
            transform.position.y >= movementBounds.max.y - 0.2f)
        {
            newDirection.y *= -1;
            changedDirection = true;
            newPosition.y = Mathf.Clamp(newPosition.y,
                movementBounds.min.y + 0.2f,
                movementBounds.max.y - 0.2f);
        }

        if (changedDirection)
        {
            direction = newDirection.normalized;
            // Добавляем случайность
            direction += Random.insideUnitCircle * 0.3f;
            direction = direction.normalized;
            transform.position = newPosition;
        }
    }

    void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        if (gameManager != null)
        {
            gameManager.HandleMouseClick();
            Destroy(gameObject);
        }
    }
}
