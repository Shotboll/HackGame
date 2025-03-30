using UnityEngine;

public class PlayerComponent : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInputX;
    private float moveInputY;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        moveInputX = Input.GetAxis("Horizontal");
        moveInputY = Input.GetAxis("Vertical");
        rb.linearVelocity = new Vector2(moveInputY * speed, rb.linearVelocity.y);
        rb.linearVelocity = new Vector2(moveInputX * speed, rb.linearVelocity.x);
        if(!facingRight && moveInputX > 0)
        {
            Flip();
        }
        else if(facingRight && moveInputX < 0)
        {
            Flip();
        }
        if(moveInputX == 0 && moveInputY == 0)
        {
            anim.SetBool("isWalk", false);
        }
        else
        {
            anim.SetBool("isWalk", true);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
