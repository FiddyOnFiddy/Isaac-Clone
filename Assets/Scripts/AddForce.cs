using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{

    private Rigidbody2D rb;
    private ShootScript shootScript;

    public float tearLife = 2.0f;
    public float defaultTearLife;
    public int shootDir;

    // Use this for initialization
    void Start()
    {
        shootScript = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootScript>();
        if (shootScript.shootDir == 1)
        {


        }

    }


    // Update is called once per frame
    void Update()
    {
        tearLife -= Time.fixedDeltaTime;


       /* if (tearLife <= 0.0f)
        {
            Destroy(gameObject);
        }

        if (shootScript.shootDir == 1)
        {
            transform.Translate(Vector3.up * Time.fixedDeltaTime);
        }
        if (shootScript.shootDir == 2)
        {
            transform.Translate(Vector3.down * Time.fixedDeltaTime);
        }
        if (shootScript.shootDir == 3)
        {
            transform.Translate(Vector3.left * Time.fixedDeltaTime);
        }
        if (shootScript.shootDir == 4)
        {
            transform.Translate(Vector3.right * Time.fixedDeltaTime);
        }
    }*/
}