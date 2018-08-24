using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemScript : MonoBehaviour
{

    public List<GameObject> items;

	// Use this for initialization
	void Start ()
    {
        items = new List<GameObject>(); 
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "item")
        {

        }
    }
}
