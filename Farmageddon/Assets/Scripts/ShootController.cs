using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour {

    public GunWeapon currentGunWeapon;
    public GameObject player;
    public AudioClip fireSound;
    float lastFired = 0;

    [HideInInspector]public float damage;
    private float bulletSpeed;
    private float fireRate;
    private bool isAutomatic;
    private bool isShotgun;
    private int spreadAmount;
    private int bulletAmount;
    private float screenShake;
    private BulletScript bulletScript;

    private GameObject bullet;
    private Rigidbody2D bulletRB;
    private SpriteRenderer bulletSR;

    private Sprite gameBullet;
    [HideInInspector]public GameObject clone;

    void Config ()
    {
        screenShake = currentGunWeapon.screenShake;
        fireSound = currentGunWeapon.fireSound;
        damage = currentGunWeapon.damage;
        bulletSpeed = currentGunWeapon.speed;
        fireRate = currentGunWeapon.fireRate;
        isAutomatic = currentGunWeapon.isAutomatic;
        isShotgun = currentGunWeapon.isShotgun;
        bulletAmount = currentGunWeapon.bulletAmount;
        spreadAmount = currentGunWeapon.spreadAmount;
        gameBullet = currentGunWeapon.gameBullet;
        if(!isShotgun){bulletAmount = 1;}
        bullet = new GameObject();
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (!isAutomatic && Input.GetButtonDown("Fire1"))
        {
               Shoot();
        }

        if (isAutomatic && Input.GetButton("Fire1"))
        {
            if (Time.time - lastFired > 1 / fireRate)
            {
               lastFired = Time.time;
               Shoot();
            }

        }
	}

    void Shoot()
    {
        Config();

            for (int i = 0; i < bulletAmount; i++)
            {
            clone = (GameObject)Instantiate(bullet);
            clone.tag = "Weapon";

            clone.AddComponent<SpriteRenderer>();
            clone.GetComponent<SpriteRenderer>().sprite = gameBullet;
            clone.GetComponent<SpriteRenderer>().sortingOrder = -1;

            clone.AddComponent<Rigidbody2D>();
            bulletRB = clone.GetComponent<Rigidbody2D>();
            bulletRB.gravityScale = 0;
            bulletRB.constraints = RigidbodyConstraints2D.FreezeRotation;
            bulletRB.bodyType = RigidbodyType2D.Kinematic;

            clone.AddComponent<BoxCollider2D>().enabled = true;
            clone.GetComponent<BoxCollider2D>().isTrigger = true;

            clone.AddComponent(typeof(BulletScript));
            bulletScript = clone.GetComponent<BulletScript>();
            bulletScript.screenShake = screenShake;
            bulletScript.damage = damage;
            
            clone.AddComponent<AudioSource>().enabled = true;
            clone.AddComponent<AudioSource>().volume = 0.5f;
            clone.GetComponent<AudioSource>().clip = fireSound;
            clone.GetComponent<AudioSource>().Play();
        
            clone.transform.localScale = new Vector3(1, 1, 0);

            clone.transform.position = gameObject.transform.position;
            clone.transform.rotation = gameObject.transform.rotation;

            if(isShotgun)
            {
                clone.transform.Rotate(0, 0, ((i - ((bulletAmount / 2)))) * spreadAmount); //Transform is over-written if it's a shotgun
            }

            clone.GetComponent<Rigidbody2D>().velocity = new Vector2(clone.transform.up.y * bulletSpeed, clone.transform.right.y * bulletSpeed);

            Destroy(bullet);
            }
    }
}
