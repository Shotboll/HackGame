using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject mousePrefab;
    public float baseSpeed = 3f;
    public float speedMultiplier = 1.2f;
    public TextMeshProUGUI scoreText;

    private int currentScore;
    private bool gameRunning = true;
    private float currentSpeed;
    private bool canSpawn = true; // Флаг для контроля спавна

    public Collider2D boundaryCollider;

    void Start()
    {
        currentSpeed = baseSpeed;
        SpawnMouse();
    }

    void SpawnMouse()
    {
        Bounds bounds = boundaryCollider.bounds;
        Vector2 spawnPos = new Vector2(
            Random.Range(bounds.min.x + 0.5f, bounds.max.x - 0.5f),
            Random.Range(bounds.min.y + 0.5f, bounds.max.y - 0.5f)
        );

        GameObject mouse = Instantiate(mousePrefab, spawnPos, Quaternion.identity);
        mouse.GetComponent<MouseController>().Initialize(
            this,
            currentSpeed,
            boundaryCollider.bounds
        );
    }

    public void HandleMouseClick()
    {
        currentScore++;
        currentSpeed *= speedMultiplier;
        UpdateScoreDisplay();

        if (currentScore >= 10)
        {
            EndGame();
        }
        else
        {
            StartCoroutine(SpawnWithDelay()); // Запускаем корутину после клика
        }
    }

    IEnumerator SpawnWithDelay()
    {
        canSpawn = false;
        yield return new WaitForSeconds(3f);
        SpawnMouse();
        canSpawn = true;
    }

    void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {currentScore}/10";
        }
    }

    void EndGame()
    {
        gameRunning = false;
        StopAllCoroutines();
        Debug.Log("Game Over!");
    }
}