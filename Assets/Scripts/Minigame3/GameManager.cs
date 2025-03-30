using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score = 0;
    public Text scoreText;
    public GameObject ratPrefab;  // ������ �����
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
        // ���� ����� ������ 10 �����, ��������� ����
        if (score >= 10 && !gameOver)
        {
            gameOver = true;
            Debug.Log("���� ���������! �� �������!");
            // ����� ����� �������� ������ ��� ���������� ���� (��������, �������� ����� ������ ��� ����������)
        }
    }

    public void AddScore()
    {
        score++;
        if (scoreText != null)
        {
            scoreText.text = "����: " + score;
        }
        Debug.Log("���� ���������! ������: " + score);
    }

    // ����� ��� �������� ����� �����
    public void SpawnRat(float speed)
    {
        // ������ ��������� ������� �� �����
        float x = Random.Range(-7f, 7f);
        float y = Random.Range(-4f, 4f);
        Vector2 spawnPosition = new Vector2(x, y);

        // ������� �����
        GameObject newRat = Instantiate(ratPrefab, spawnPosition, Quaternion.identity);

        // �������� ��������� RatMovement � ����������� ��������
        RatMovement ratMovement = newRat.GetComponent<RatMovement>();
        if (ratMovement != null)
        {
            ratMovement.speed = speed;  // ������������� ����� ��������
        }
    }
}