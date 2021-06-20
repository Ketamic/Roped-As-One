using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMovement2 : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float moveInput;

    private bool isGrounded;
    private bool isGrounded2;
    private bool isGrounded3;
    private bool isJumping;
    public Transform feetPos;
    public Transform feetPos2;
    public Transform feetPos3;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;

    public AudioSource jump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        isGrounded2 = Physics2D.OverlapCircle(feetPos2.position, checkRadius, whatIsGround);
        isGrounded3 = Physics2D.OverlapCircle(feetPos3.position, checkRadius, whatIsGround);


        if ((isGrounded == true || isGrounded2 == true || isGrounded3) && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if(jumpTimeCounter > 0)
            {
                jump.Play();
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            } else
            {
                isJumping = false;
            }
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }
}
