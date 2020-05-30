using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{ 
    // movement variables
    public float maxSpeed;

    // friction material
    public PhysicsMaterial2D withFriction;
    public PhysicsMaterial2D noFriction;

    // jumping variables
    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;
    public Rigidbody2D player;

    Rigidbody2D myRB;
    Animator myAnim;
    bool facingRight;


    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        facingRight = true;
                    
    }

    // Update is called once per frame

    void Update()
    {
        if (grounded && Input.GetButtonDown("Jump"))
        {
            grounded = false;
            myAnim.SetBool("isGrounded", grounded);
            myRB.AddForce(new Vector2(0, jumpHeight));
        }

    }
    void FixedUpdate()
    {

        // check if we are grounded - if no then we are falling
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myAnim.SetBool("isGrounded", grounded);

        myAnim.SetFloat("verticalSpeed", myRB.velocity.y);

        float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("speed", Mathf.Abs(move));

        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);

        if(move == 0)
        {
            // change physics material to withFriction
            player.sharedMaterial = withFriction;
        }
        else
        {
            // change physics material to noFriction
            player.sharedMaterial = noFriction;
        }

        if (move>0 && !facingRight)
        {
            flip();
        }
        else if (move<0 && facingRight)
        {
            flip();
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
