using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jump;
    public float maxVelocity;
    private Vector2 move;

    public float groundCheckRadius = 0.6f;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        if (System.Math.Abs(rb.velocity.x + move.x * speed * Time.deltaTime) < maxVelocity)
        {
            rb.AddForce(speed * Time.deltaTime * move);
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer);
    }
}
