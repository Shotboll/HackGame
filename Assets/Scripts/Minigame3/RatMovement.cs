using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class RatMovement : MonoBehaviour 
{
    public float speed = 3f;
    private Vector2 targetPosition;

    void Start()
    {
        SetNewTarget();
    }

    void Update()
    {
        MoveToTarget();
    }

    void SetNewTarget()
    {
        float x = Random.Range(-7f, 7f); // Границы карты
        float y = Random.Range(-4f, 4f);
        targetPosition = new Vector2(x, y);
    }
    void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetNewTarget();
        }
    }
}
