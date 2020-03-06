using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;               
    private Rigidbody2D rb2d;
    public float jumpForce = 35;
    private bool isGrounded;
 
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        isGrounded = true;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        if (isMovingHorizontal() && isGrounded)
        {
            rb2d.isKinematic = false;
            rb2d.velocity = movement * speed;
        }

        if (!Input.anyKey && isGrounded)
        {
            rb2d.isKinematic = true;
            rb2d.velocity = Vector2.zero;
        }

        if (isJumping() && isGrounded)
        {
            rb2d.isKinematic = false;
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
       
    }

    bool isMovingHorizontal()
    {
        return Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)
            || Input.GetKey(KeyCode.D)
            || Input.GetKey(KeyCode.A);
    }

    bool isJumping()
    {
        return Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

}
