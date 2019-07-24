using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;               
    private Rigidbody2D rb2d;
    private Collider2D col; 
    private float jumpForce = 100;
    private bool isGrounded;
 
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.velocity = movement * speed;
        }

        if (Input.GetKey(KeyCode.UpArrow) && isGrounded)
        {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
    
    private void OnCollisionStay2D()
    {
        isGrounded = true;
    }

    private void OnCollisionExit3D()
    {
        isGrounded = false;
    }


}
