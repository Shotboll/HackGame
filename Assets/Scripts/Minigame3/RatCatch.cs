using UnityEngine;

public class RatCatch : MonoBehaviour
{
    private void Start()
    {
        // Создаем первую крысу с начальной скоростью
        GameManager.Instance.SpawnRat(3f);  // Начальная скорость крысы 3
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ЛКМ
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mousePos);

            if (hit != null && hit.gameObject == gameObject) // Проверяем, это ли крыса
            {
                GameManager.Instance.AddScore();  // Засчитываем очки
                Destroy(gameObject);  // Удаляем текущую крысу

                // Создаем новую крысу с увеличенной скоростью
                float newSpeed = 3f + GameManager.Instance.score * 0.5f;  // Скорость увеличивается с каждым очком
                GameManager.Instance.SpawnRat(newSpeed);  // Создаем крысу с новой скоростью
            }
        }
    }
}