using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;

    public float movementSpeed;
    public Vector2 moveVelocity;

    public Sprite halfHeartContainer;
    public Sprite emptyHeartContainer;
    public Sprite heartSprite;

    public Image[] heartContainers;

    public PlayerStatsScript playerStats;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerStats = GetComponent<PlayerStatsScript>();

        

    }
	
	// Update is called once per frame
	void Update ()
    {

        ShowHeartContainers();

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * movementSpeed;

    }

    public void ShowHeartContainers()
    {
        for (int i = 0; i < heartContainers.Length; i++)
        {
            if (i < playerStats.health)
            {
                heartContainers[i].sprite = heartSprite;
            }
            else
            {
                heartContainers[i].sprite = emptyHeartContainer;
            }


            if (i < playerStats.heartContainers)
            {
                heartContainers[i].enabled = true;
            }
            else
            {
                heartContainers[i].enabled = false;
            }
        }
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
        if (collision.tag == "Enemy")
        {
            playerStats.health -= 1;
            Debug.Log("collided");
        }

        if (collision.tag == "Heart")
        {

        }

        if (collision.tag == "HpUp")
        {
            playerStats.heartContainers += 1;
            playerStats.health += 1;
        }

        if (collision.tag == "HpDown")
        {
            playerStats.heartContainers -= 1;
        }
    }
}
