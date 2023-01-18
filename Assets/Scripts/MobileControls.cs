using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;



public class MobileControls : MonoBehaviour
{
    [SerializeField] float horizontalInput;
    [SerializeField] float speed = 5;
    [SerializeField] float jumpHeight = 5f;
    [SerializeField] float boostHeight = 100f;

    [SerializeField] Animator playerAnim;
    SpriteRenderer characterScale;
    Rigidbody2D playerRb;
    

    public bool isGrounded = true;
    bool moveLeft = false;
    bool moveRight = false;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        characterScale = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

    public void MoveRight()
    {
        playerRb.velocity = new Vector2(speed, 0f);
    }
    public void MoveLeft()
    {
        playerRb.velocity = new Vector2(-speed, 0f);
    }

    public void Jump()
    {
            playerRb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
           isGrounded = false;
    }

    public void stopMoving()
    {
        playerRb.velocity = Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Platform" && !isGrounded)
        {
            isGrounded = true;
        }
        if(other.gameObject.tag == "Jump Pad")
        {
            playerRb.AddForce(Vector2.up * boostHeight, ForceMode2D.Impulse);
        }
    }
}
