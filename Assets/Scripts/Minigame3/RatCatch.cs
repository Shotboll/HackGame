using UnityEngine;

public class RatCatch : MonoBehaviour
{
    private void Start()
    {
        // ������� ������ ����� � ��������� ���������
        GameManager.Instance.SpawnRat(3f);  // ��������� �������� ����� 3
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mousePos);

            if (hit != null && hit.gameObject == gameObject) // ���������, ��� �� �����
            {
                GameManager.Instance.AddScore();  // ����������� ����
                Destroy(gameObject);  // ������� ������� �����

                // ������� ����� ����� � ����������� ���������
                float newSpeed = 3f + GameManager.Instance.score * 0.5f;  // �������� ������������� � ������ �����
                GameManager.Instance.SpawnRat(newSpeed);  // ������� ����� � ����� ���������
            }
        }
    }
}