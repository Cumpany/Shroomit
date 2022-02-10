using System.Data.SqlTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator animator;

    public Rigidbody2D rb;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        // var cHorizontal = rb.velocity.x;
        // var cVertical = rb.velocity.y;
        // if (cHorizontal < 0)
        // {
        //     cHorizontal = -cHorizontal;
        // }
        // if (cVertical < 0)
        // {
        //     cVertical = -cVertical;
        // }
        // bool priority;
        // if (cHorizontal < cVertical)
        // {
        //     priority = true;
        // }
        // else
        // {
        //     priority = false;
        // }

        // if (!priority && horizontal != 0)
        // {
        //     vertical = 0;
        // }
        // else if (priority && vertical != 0)
        // {
        //     horizontal = 0;
        // }
    }

 void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
        
        if (horizontal > 0)
        {
            animator.SetBool("IsWalkingRight", true);
            animator.SetBool("IsWalkingLeft", false);
            animator.SetBool("IsWalkingUp", false);
            animator.SetBool("IsWalkingDown", false);
        }
        else if (horizontal < 0)
        {
            animator.SetBool("IsWalkingLeft", true);
            animator.SetBool("IsWalkingRight", false);
            animator.SetBool("IsWalkingUp", false);
            animator.SetBool("IsWalkingDown", false);
        }

        if (vertical > 0)
        {
            animator.SetBool("IsWalkingUp", true);
            animator.SetBool("IsWalkingDown", false);
            animator.SetBool("IsWalkingRight", false);
            animator.SetBool("IsWalkingLeft", false);
        }
        else if (vertical < 0)
        {
            animator.SetBool("IsWalkingDown", true);
            animator.SetBool("IsWalkingUp", false);
            animator.SetBool("IsWalkingRight", false);
            animator.SetBool("IsWalkingLeft", false);
        }

        if (horizontal == 0 && vertical == 0)
        {
            animator.SetBool("IsWalkingDown", false);
            animator.SetBool("IsWalkingUp", false);
            animator.SetBool("IsWalkingRight", false);
            animator.SetBool("IsWalkingLeft", false);
        }
        rb.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
