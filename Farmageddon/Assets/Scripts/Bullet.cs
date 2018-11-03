using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    GunWeapon gunBullet;
    public Sprite currentBullet;
    mouseCursor cursor;
	// Use this for initialization
	void Start ()
    {
        currentBullet = gunBullet.gameBullet;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    	
	}
}
