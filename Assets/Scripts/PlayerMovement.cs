using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TO DO: Make left and right control keys hotswappable

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpForce = 5f;
    public float horizontal;

    public bool isRight;

    public KeyCode jump;
    public KeyCode left;
    public KeyCode right;
    public KeyCode talk;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(jump) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetKeyUp(jump) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        //if (Input.GetKeyDown(left))
        //{
        //   rb.velocity = new Vector2(moveSpeed * -1f, rb.velocity.y);
        //}

        //if (Input.GetKeyDown(right))
        //{
        //   rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        //}

        Flip();

    }

    private void FixedUpdate()
    {
       rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);
    }

    private void Flip()
    {
        if(isRight && rb.velocity.x < 0f || !isRight && rb.velocity.x > 0f)
        {
            isRight = !isRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }   
}
