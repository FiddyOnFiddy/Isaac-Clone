using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;

    public float movementSpeed;
    public Vector2 moveVelocity;

    public Canvas canvas;
    public Sprite halfHeartContainer;
    public Image heartContainer3;

    public Image[] heartContainers;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        heartContainers = new Image[11];

        heartContainers = canvas.GetComponentsInChildren<Image>();

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Debug.Log("collided");
            heartContainer3.sprite = halfHeartContainer;
        }
    }
}
