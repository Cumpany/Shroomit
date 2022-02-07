using System.Data.SqlTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;

    float horizontal;
    float vertical;

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
        var cHorizontal = rb.velocity.x;
        var cVertical = rb.velocity.y;
        if (cHorizontal < 0)
        {
            cHorizontal = -cHorizontal;
        }
        if (cVertical < 0)
        {
            cVertical = -cVertical;
        }
        bool priority;
        if (cHorizontal < cVertical)
        {
            priority = true;
        }
        else
        {
            priority = false;
        }

        if (!priority && horizontal != 0)
        {
            vertical = 0;
        }
        else if (priority && vertical != 0)
        {
            horizontal = 0;
        }
    }

 void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
