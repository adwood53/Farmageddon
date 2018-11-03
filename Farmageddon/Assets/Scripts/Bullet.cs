using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    GunWeapon gunBullet;
    public Sprite currentBullet;
    mouseCursor cursor;

    public float speed;
	// Use this for initialization
	void Start ()
    {
        currentBullet = gunBullet.gameBullet;
        speed = gunBullet.speed;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
}
