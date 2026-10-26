using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Global variables - any function in this script can access them
    //public means any other script can acccess it, and it's
    //visible in the editor!
    public float moveSpeed;
    public bool hasKey = false;
    //Jump, go ahead and jump
    public float jumpHeight;
    public float fallMarkiplier = 2.5f; //Increase gravity
    public float hopMarkiplier = 2f; //Tap vs hold like a mario game
    public bool isGrounded; //Are you on the ground? (now!)
    public LayerMask groundLayer; //For da ground, now
    public float groundCheckLength = 1.25f;
    public int coinscollected;
    public TMP_Text coinDisplay;

    //Toonie Lunes
    public float coyoteTime;
    public float coyoteTimeMax = 0.25f;

    //Rigidbody2D is a component type variable.
    private Rigidbody2D rb2d;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize the rb2d variable
        rb2d = GetComponent<Rigidbody2D>();

        sr = GetComponent<SpriteRenderer>();

        //Reset coyote time
        coyoteTime = coyoteTimeMax;
    }

    // Update is called once per frame
    void Update()
    {
        //Local variable of type float to store the horizontal input
        float h = Input.GetAxis("Horizontal");

        //Call the MoveCharacter function and send it the value
        //of h (-1, 0 or +1)
        MoveCharacter(h);

        //Assign the value of isGrounded to the return value of function
        isGrounded = GroundCheck();

        //if player is grounded, reset
        //if they aint count down using delta time
        if (isGrounded)
        {
            coyoteTime = coyoteTimeMax;
        }
        else
        {
            coyoteTime -= Time.deltaTime;
        }

        if (coyoteTime > 0 && Input.GetKey(KeyCode.Space))
        {
            //Set the rigidbody2D velocity to whatever x is and jump on y
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpHeight);
        }

        //Gravity modifiers
        if (rb2d.linearVelocity.y < 0)
        {
            rb2d.linearVelocity += ((Vector2.up * Physics2D.gravity) * (fallMarkiplier * Time.deltaTime));
        }

        else if (rb2d.linearVelocity.y > 0 && !Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.linearVelocity += ((Vector2.up * Physics2D.gravity) * (hopMarkiplier * Time.deltaTime));
        }
    }


    //The MoveCharacter function has a float in the brackets
    //(parameters or arguments) and can use the value it was sent!
    void MoveCharacter(float hMove)
    {
        //Now that we have that information, apply it to the rb2d
        //to make the character move!

        //A vector is a representation of direction/rotation/scale
        //(x, y, z). Velocity is a vector!
        rb2d.linearVelocity = new Vector2(hMove * moveSpeed, 
            rb2d.linearVelocity.y);

        //If the player if facing left, flip horizontally
        if (hMove < 0)
        {
            sr.flipX = true;
        }
        else if (hMove >0)
        {
            sr.flipX = false;
        }
    }

    bool GroundCheck()
    {
        //Raycasts are lines detecting collision that return true or false
        //They have 2 parameters, starting point and direction plus up to 7 others if desired
        bool check = Physics2D.Raycast(transform.position, Vector2.down, groundCheckLength, groundLayer);

        //return bling bling boy's value
        return check;
    }
}
