using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject tear;
    public Rigidbody2D rb;

    public float tearDelay;
    public float defaultTearDelay;

    public float force = 500;
    public float movementForce = 15;


    private PlayerMovement playerMovement;

    // Use this for initialization
    void Start ()
    {
        rb = tear.GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();

        defaultTearDelay = tearDelay;
	}
	
	// Update is called once per frame
	void Update ()
    {
        ShootTear();
        tearDelay -= Time.fixedDeltaTime;
    }

    public void ShootTear()
    {
        if(Input.GetKey(KeyCode.UpArrow) && tearDelay <= 0)
        {
            SpawnTear(Vector2.up);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && tearDelay <= 0)
        {
            SpawnTear(Vector2.down);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && tearDelay <= 0)
        {
            SpawnTear(Vector2.right);
    
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && tearDelay <= 0)
        {
            SpawnTear(Vector2.left);
        }
    }

    void SpawnTear(Vector2 shootDirection)
    {
        GameObject clone = Instantiate(tear, transform.position, Quaternion.identity);
        Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
        rb.AddForce(shootDirection * force * Time.fixedDeltaTime, ForceMode2D.Impulse);
        rb.AddForce(playerMovement.moveVelocity * movementForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
        tearDelay = defaultTearDelay;
    }
}
