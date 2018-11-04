using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedPlayerScript : MonoBehaviour {

    private Vector2 movement;
    private Animator animator;

    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();   	
	}
	
	// Update is called once per frame
	void Update ()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        if(movement.y > 0)
        {
            animator.SetTrigger("PlayerUp");
        }

        else if (movement.x < 0)
        {
            animator.SetTrigger("PlayerLeft");
        }

        else if (movement.y < 0)
        {
            animator.SetTrigger("PlayerDown");
        }

        else if (movement.x > 0)
        {
            animator.SetTrigger("PlayerRight");
        }

        else
        {
            animator.SetTrigger("PlayerIdle");
        }

    }
}
