using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject tear;
    public Rigidbody2D rb;
    public Vector2 shootDirection;

    public float tearDelay;
    public float defaultTearDelay;

    public bool isShooting = false;

    public int shootDir = 0;

    // Use this for initialization
    void Start ()
    {
        rb = tear.GetComponent<Rigidbody2D>();

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
            SpawnTear();
            shootDir = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && tearDelay <= 0)
        {
            SpawnTear();
            shootDir = 2;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && tearDelay <= 0)
        {
            SpawnTear();
            shootDir = 4;
    
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && tearDelay <= 0)
        {
            SpawnTear();
            shootDir = 3;
        }
    }

    void SpawnTear()
    {
        Instantiate(tear, transform.position, Quaternion.identity);
        tearDelay = defaultTearDelay;
    }
}
