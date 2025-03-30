using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score = 0;
    public Text scoreText;
    public GameObject ratPrefab;  // Префаб крысы
    private bool gameOver = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Update()
    {
        // Если игрок набрал 10 очков, завершаем игру
        if (score >= 10 && !gameOver)
        {
            gameOver = true;
            Debug.Log("Игра завершена! Ты победил!");
            // Здесь можно добавить логику для завершения игры (например, показать экран победы или перезапуск)
        }
    }

    public void AddScore()
    {
        score++;
        if (scoreText != null)
        {
            scoreText.text = "Очки: " + score;
        }
        Debug.Log("Очки увеличены! Теперь: " + score);
    }

    // Метод для создания новой крысы
    public void SpawnRat(float speed)
    {
        // Задаем случайную позицию на карте
        float x = Random.Range(-7f, 7f);
        float y = Random.Range(-4f, 4f);
        Vector2 spawnPosition = new Vector2(x, y);

        // Создаем крысу
        GameObject newRat = Instantiate(ratPrefab, spawnPosition, Quaternion.identity);

        // Получаем компонент RatMovement и увеличиваем скорость
        RatMovement ratMovement = newRat.GetComponent<RatMovement>();
        if (ratMovement != null)
        {
            ratMovement.speed = speed;  // Устанавливаем новую скорость
        }
    }
}