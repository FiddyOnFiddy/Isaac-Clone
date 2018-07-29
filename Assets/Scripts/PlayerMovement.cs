using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;

    public float movementSpeed;


    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Movement();
	}

    public void Movement()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {

            Input.
            rb.velocity = new Vector2(movementSpeed * Time.fixedDeltaTime * 10.0f, rb.velocity.y);
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            rb.velocity = new Vector2(-movementSpeed * Time.fixedDeltaTime * 10.0f, rb.velocity.y);
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, movementSpeed * Time.fixedDeltaTime * 10.0f);
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, -movementSpeed * Time.fixedDeltaTime * 10.0f);

        }

    }
}
