using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float playerSpeed;
    public float jumpForce;

    //Is Grounded
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;

    public  Rigidbody2D myRigidbody;
    FallingController theFallingController;

    public Sprite idle;
    public Sprite moving;
    public Sprite jumping;

    SpriteRenderer theRenderer;

    public float scale;

    // Start is called before the first frame update
    void Start()
    {
        theFallingController = FindObjectOfType<FallingController>();
        myRigidbody = GetComponent<Rigidbody2D>();
        theRenderer = GetComponent<SpriteRenderer>();
        scale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (!theFallingController.gameOver && ! theFallingController.winning)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                theRenderer.sprite = moving; 
                myRigidbody.velocity = new Vector3(playerSpeed, myRigidbody.velocity.y, 0f);
                transform.localScale = new Vector3(scale, transform.localScale.y, 0);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                theRenderer.sprite = moving;
                myRigidbody.velocity = new Vector3(-playerSpeed, myRigidbody.velocity.y, 0f);
                transform.localScale = new Vector3(-scale, transform.localScale.y, 0);
            }
            else
            {
                theRenderer.sprite = idle;
                myRigidbody.velocity = new Vector3(0, myRigidbody.velocity.y, 0f);
            }

            if (isGrounded)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpForce, 0f);
                    theFallingController.jumpSound.Play();
                }
            }
            else
            {
                theRenderer.sprite = jumping;
            }
        }
    }
}
