using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EP_PlayerMoveScript : MonoBehaviour
{
    
    #region PlayerSprites
    public GameObject       playerHead;
    private SpriteRenderer  headSprite;

    public GameObject       playerTorso;
    private SpriteRenderer  torsoSprite;

    public GameObject       playerRightHand;
    private SpriteRenderer  righthandSprite;

    public GameObject       playerLeftHand;
    private SpriteRenderer  lefthandSprite;

    public GameObject       playerLeftFoot;
    private SpriteRenderer  leftfootSprite;

    public GameObject       playerRightFoot;
    private SpriteRenderer  rightfootSprite;
    #endregion

    public GameObject       PlayerContainer;
    private Animator        playerAnim;
    private Rigidbody2D     playerRB;

    public float speed =    7.5f;
    private float time;

    private bool rightFace = true;
    
    // Use this for initialization
    void Start()
    {

        playerAnim = PlayerContainer.GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody2D>();

        torsoSprite =       playerTorso.GetComponent<SpriteRenderer>();
        headSprite =        playerHead.GetComponent<SpriteRenderer>();
        righthandSprite =   playerRightHand.GetComponent<SpriteRenderer>();
        lefthandSprite =    playerLeftHand.GetComponent<SpriteRenderer>();
        leftfootSprite =    playerLeftFoot.GetComponent<SpriteRenderer>();
        rightfootSprite =   playerRightFoot.GetComponent<SpriteRenderer>();
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
        if (time >= 0.75f)
            time = 0.75f;

        if(Input.GetKey(KeyCode.D))
        {

            rightFace = true;
            playerRB.AddForce(Vector2.right * (speed * time));
            playerAnim.SetBool("runningRight", true);
            playerAnim.SetBool("idle", false);

            torsoSprite.flipX =             false;
            headSprite.flipX =              false;
            righthandSprite.sortingOrder =  0;
            lefthandSprite.sortingOrder =   2;
            leftfootSprite.flipX =          false;
            rightfootSprite.flipX =         false;

            if (Input.GetKey(KeyCode.A))
            {

                playerAnim.SetBool("runningLeft", true);
                playerAnim.SetBool("runningRight", false);

                torsoSprite.flipX =             true;
                headSprite.flipX =              true;
                righthandSprite.sortingOrder =  2;
                lefthandSprite.sortingOrder =   0;
                leftfootSprite.flipX =          true;
                rightfootSprite.flipX =         true;

            }
        }

        else if (Input.GetKeyUp(KeyCode.D))
        {

            rightFace = true;
            playerRB.velocity = Vector2.right * 2;
            playerAnim.SetBool("runningRight", false);
            playerAnim.SetBool("idle", true);

        }

        if (Input.GetKey(KeyCode.A))
        {

            rightFace = false;
            playerRB.AddForce(Vector2.left * (speed * time));
            playerAnim.SetBool("runningLeft", true);
            playerAnim.SetBool("idle", false);

            torsoSprite.flipX =             true;
            headSprite.flipX =              true;
            righthandSprite.sortingOrder =  2;
            lefthandSprite.sortingOrder =   0;
            leftfootSprite.flipX =          true;
            rightfootSprite.flipX =         true;

            if (Input.GetKey(KeyCode.D))
            {
                
                playerAnim.SetBool("runningRight", true);
                playerAnim.SetBool("runningLeft", false);

                torsoSprite.flipX =             false;
                headSprite.flipX =              false;
                righthandSprite.sortingOrder =  0;
                lefthandSprite.sortingOrder =   2;
                leftfootSprite.flipX =          false;
                rightfootSprite.flipX =         false;

            }

        }

        else if (Input.GetKeyUp(KeyCode.A))
        {

            rightFace = false;
            playerRB.velocity = Vector2.left * 2;
            playerAnim.SetBool("runningLeft", false);
            playerAnim.SetBool("idle", true);

        }

        else
        {
            
            playerRB.AddForce(playerRB.velocity / 20);

        }

        time += Time.deltaTime;
    }
}
