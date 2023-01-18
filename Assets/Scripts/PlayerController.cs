 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool moveLeft;
    private bool moveRight;
    private float horizontalMove;
    public float speed = 5;

    [SerializeField] float jumpHeight = 5f;
    [SerializeField] float boostHeight = 15f;

    public bool isGrounded = true;


 void Start()
    {
       rb = GetComponent<Rigidbody2D>();
 
       moveLeft = false;
       moveRight = false; 
    }
 
    public void PointerDownLeft()
    {
        moveLeft = true;
    }
 
    public void PointerUpLeft()
    {
        moveLeft = false;
    }
 
    public void PointerDownRight()
    {
        moveRight = true;
    }
 
    public void PointerUpRight()
    {
        moveRight = false;
    }

     public void Jump()
    {
        if(isGrounded)
        {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
           isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Platform" && !isGrounded)
        {
            isGrounded = true;
        }
        if(other.gameObject.tag == "Jump Pad")
        {
            rb.AddForce(Vector2.up * boostHeight, ForceMode2D.Impulse);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Platform")
        {
            isGrounded = false;
        }
    }
 
    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
 
    private void MovePlayer()
    {
        if (moveLeft)
        {
            horizontalMove = -speed;
        }
        else if (moveRight)
        {
            horizontalMove = speed;
        }
        else
        {
            horizontalMove = 0;
        }
    }
 
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }
}