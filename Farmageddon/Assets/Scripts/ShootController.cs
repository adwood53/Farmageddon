using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour {

    public Vector2 speed;

    Rigidbody2D rb2d;

	// Use this for initialization
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = speed;
	}
	
	// Update is called once per frame
	void Update ()
    {
        rb2d.velocity = speed;
	}
}
