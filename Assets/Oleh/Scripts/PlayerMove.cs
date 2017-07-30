using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    Rigidbody2D rb;
    float horizontal;
    bool faceRight;
    // Use this for initialization
    void Start ()
    {
        faceRight = true;
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        horizontal = Input.GetAxis("Horizontal");

        HandelMovement();

        Flip();
	}

    void HandelMovement()
    {

        rb.velocity = new Vector2(horizontal * 3, 0.0f);
    }

    void Flip()
    {
        if(horizontal > 0 && !faceRight || horizontal < 0 && faceRight)
        {
            faceRight = !faceRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
