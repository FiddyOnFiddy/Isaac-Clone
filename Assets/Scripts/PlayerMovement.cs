using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;

    public float movementSpeed;
    public Vector2 moveVelocity;
        


    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * movementSpeed;

    }

    private void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        rb.AddForce(moveVelocity * 500 * Time.fixedDeltaTime);
        
    }
}
