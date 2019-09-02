using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ingredient = Data.IngredientCollectibles;

public class PlayerController : MonoBehaviour
{
    public float speed;               
    private Rigidbody2D rb2d;
    private Collider2D col;
    public float jumpForce = 35;
    private bool isGrounded;

    private ArrayList inventory = new ArrayList();
 
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        isGrounded = true;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && isGrounded)
        {
            rb2d.isKinematic = false;
            rb2d.velocity = movement * speed;
        }

        if (!Input.anyKey && isGrounded)
        {
            rb2d.isKinematic = true;
            rb2d.velocity = Vector2.zero;
        }

        if (Input.GetKey(KeyCode.UpArrow) && isGrounded)
        {
            rb2d.isKinematic = false;
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
       
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log(string.Format("trigger"));
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (other.gameObject.CompareTag("Ingredient"))
        {
            HandleIngredientCollection(other.gameObject);
        }
    }

    private void HandleIngredientCollection(GameObject gameObject)
    {
        IngredientCollectibleBehaviour ingredientBehaviour = gameObject.GetComponent<IngredientCollectibleBehaviour>();
        if (ingredientBehaviour != null)
        {
            Ingredient ingredient = ingredientBehaviour.getIngredient();
            inventory.Add(ingredient); 
            Debug.Log(string.Format("Ingredient {0} was added", gameObject.name));
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log(string.Format("gameObject {0} did not contain {1}", gameObject.name, ingredientBehaviour.name));
        }
    }

}
