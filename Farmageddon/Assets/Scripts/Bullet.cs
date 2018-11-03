using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    GunWeapon gunBullet;
    private Sprite currentBullet;
    mouseCursor cursor;
    CharacterControllerNew attack;

    private Rigidbody2D rb;


    public Transform bulletSpawner;

    private float speed;
	// Use this for initialization
	void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        currentBullet = gunBullet.gameBullet;
        speed = gunBullet.speed;
        cursor = cursor.GetComponent<mouseCursor>();
	}
	
	// Update is called once per frame
	void Update ()
    {
       /* if(Input.GetMouseButtonDown(0))
        {
            var position = Vector2(Input.mousePosition.x, Input.mousePosition.y);
            var bullet = Instantiate(gunBullet, transform.position, currentCursor) as GameObject;
            bullet.transform.LookAt(position);
            rb.AddForce(bullet.transform.forward * speed);
        }*/
	}
}
