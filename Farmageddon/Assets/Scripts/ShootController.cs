using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour {

    public Vector2 speed;

    Rigidbody2D rb2d;

    public GunWeapon currentGunWeapon;

    private float damage;
    private float bulletSpeed;
    private float fireRate;
    Transform firePoint;

    private GameObject bullet;
    private Rigidbody2D bulletRB;
    private SpriteRenderer bulletSR;

    private Sprite gameBullet;
    private GameObject clone;

    

	// Use this for initialization
	void Start ()
    {
        gameBullet = currentGunWeapon.gameBullet;
        

        bullet = new GameObject();
        bullet.AddComponent<SpriteRenderer>();
        bullet.AddComponent<Rigidbody2D>();
        bullet.AddComponent<BoxCollider2D>();

        bulletRB = bullet.GetComponent<Rigidbody2D>();
        bullet.GetComponent<SpriteRenderer>().sprite = gameBullet;

        damage = currentGunWeapon.damage;
        bulletSpeed = currentGunWeapon.speed;
        fireRate = currentGunWeapon.fireRate;

        bulletRB.gravityScale = 0;
        bulletRB.constraints = RigidbodyConstraints2D.FreezeRotation;
        bulletRB.bodyType = RigidbodyType2D.Kinematic;

       
        //bulletRB.velocity.Set(gameObject.transform.forward.x * bulletSpeed, gameObject.transform.forward.y * bulletSpeed);
        //bulletRB.AddForce(new Vector2(10, 10));
        bullet.transform.localScale = new Vector3(1, 1, 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        bullet.transform.position = gameObject.transform.position;
        bullet.transform.rotation = gameObject.transform.rotation;
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
	}

    void Shoot()
    {
        
        clone = (GameObject) Instantiate(bullet);
        clone.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(clone.transform.rotation.z*4) * bulletSpeed, Mathf.Sin(clone.transform.rotation.z*4) * bulletSpeed);
        Debug.Log(clone.GetComponent<Rigidbody2D>().velocity);


    }
}
