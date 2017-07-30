using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    #region Static Variables
    public float MAX_SPEED = 3.0f; // Limit character to this speed
    public float SPEED = 30.0f;
    public float JUMP_POWER = 500.0f;
    #endregion

    public bool grounded;
    public bool canDoubleJump;

    private Rigidbody2D rb2d;
    //private Animator anim;

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        //anim = gameObject.GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //anim.SetBool("isGrounded", grounded);
        //anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

        //if (Input.GetAxis("Horizontal") > 0.1f)
        //    transform.localScale = new Vector3(1, 1, 1);

        //    transform.localScale.Set(-1, 1, 1);

        //if (Input.GetAxis("Horizontal") < -0.1f)
        //    transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                rb2d.AddForce(Vector2.up * JUMP_POWER);
                canDoubleJump = true;
            }

            else
            {
                if (canDoubleJump)
                {

                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                    rb2d.AddForce(Vector2.up * JUMP_POWER * 0.75f);
                    canDoubleJump = false;
                }
            }
        }
    }

    // FixedUpdate is used for Adjusting physics (Rigidbody) objects
    void FixedUpdate()
    {
        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.x *= 0.75f;

        //Fake friction -> Ease x speed of player
        if (grounded)
            rb2d.velocity = easeVelocity;

        // Move player horizontally
        float x = Input.GetAxis("Horizontal");
        rb2d.AddForce((Vector2.right * SPEED) * x);

        if (rb2d.velocity.x > MAX_SPEED)
            rb2d.velocity = new Vector2(MAX_SPEED, rb2d.velocity.y);

        if (rb2d.velocity.x < -MAX_SPEED)
            rb2d.velocity = new Vector2(-MAX_SPEED, rb2d.velocity.y);
    }
}
