using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();       
	}
	
	// Update is called once per frame
	void Update () {   

        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetBool("State", true);
            
        }

        if(Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("State", false);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetBool("State", true);

        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool("State", false);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Jump", true);

        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("Jump", false);
        }
    }
}
