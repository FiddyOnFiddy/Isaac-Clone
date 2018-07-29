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
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * movementSpeed * Time.fixedDeltaTime * 10, Input.GetAxis("Vertical") * movementSpeed * Time.fixedDeltaTime * 10);

    }
}
