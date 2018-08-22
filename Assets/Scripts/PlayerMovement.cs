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
    public Sprite emptyHeartContainer;

    public Sprite heartSprite;

    public Image[] heartContainers;

    public PlayerStatsScript playerStats;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        heartContainers = new Image[11];

        heartContainers = canvas.GetComponentsInChildren<Image>();
        playerStats = GetComponent<PlayerStatsScript>();

        

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (playerStats.heartContainers <= 12)
        {
            for (int i = 0; i < playerStats.heartContainers; i++)
            {
                heartContainers[i].color = new Vector4(heartContainers[i].color.r, heartContainers[i].color.b, heartContainers[i].color.g, 255.0f);
            }
        }
       

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
        if (collision.tag == "Enemy" && playerStats.health % 2 == 0)
        {
            Debug.Log("collided");
            playerStats.health -= 1;

            heartContainers[playerStats.health / 2 ].sprite = halfHeartContainer;
        }
        else if (collision.tag == "Enemy" && playerStats.health % 2 == 1)
        {
            Debug.Log("collided");
            playerStats.health -= 1;

            heartContainers[playerStats.health / 2].sprite = emptyHeartContainer;
        }

        if (collision.tag == "Heart")
        {
            playerStats.health += 2;

        }

        if (collision.tag == "HpUp")
        {
            if (playerStats.heartContainers <= 11)
            {
                playerStats.heartContainers += 1;
                playerStats.health += 2;
            }
        }

        if (collision.tag == "HpDown")
        {
            if (playerStats.heartContainers >= 1)
            {
                playerStats.heartContainers -= 1;
            }
            heartContainers[playerStats.heartContainers].color = new Vector4(heartContainers[playerStats.heartContainers].color.r, heartContainers[playerStats.heartContainers].color.b, heartContainers[playerStats.heartContainers].color.g, 0.0f);
        }
    }
}
