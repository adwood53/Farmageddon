using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour {

    public GunWeapon currentGunWeapon;
    public GameObject player;
    float lastFired = 0;

    [HideInInspector]public float damage;
    private float bulletSpeed;
    private float fireRate;
    private bool isAutomatic;
    private bool isShotgun;
    private int spreadAmount;
    private int bulletAmount;
    private BulletScript bulletScript;

    private GameObject bullet;
    private Rigidbody2D bulletRB;
    private SpriteRenderer bulletSR;

    private Sprite gameBullet;
    [HideInInspector]public GameObject clone;

    void Config ()
    {
        damage = currentGunWeapon.damage;
        bulletSpeed = currentGunWeapon.speed;
        fireRate = currentGunWeapon.fireRate;
        isAutomatic = currentGunWeapon.isAutomatic;
        isShotgun = currentGunWeapon.isShotgun;
        bulletAmount = currentGunWeapon.bulletAmount;
        spreadAmount = currentGunWeapon.spreadAmount;

        bullet = new GameObject();
        bullet.AddComponent<SpriteRenderer>();
        bullet.AddComponent<Rigidbody2D>();
        bulletRB = bullet.GetComponent<Rigidbody2D>();
        bullet.GetComponent<SpriteRenderer>().sprite = gameBullet;
        bullet.GetComponent<SpriteRenderer>().sortingOrder = -1;
        bullet.AddComponent<BoxCollider2D>();
        bullet.GetComponent<BoxCollider2D>().isTrigger = true;
        bullet.AddComponent(typeof(BulletScript));
        bullet.tag = "Weapon";

        gameBullet = currentGunWeapon.gameBullet;

        bulletRB.gravityScale = 0;
        bulletRB.constraints = RigidbodyConstraints2D.FreezeRotation;
        bulletRB.bodyType = RigidbodyType2D.Kinematic;

        bullet.transform.localScale = new Vector3(1, 1, 0);

        bulletScript = bullet.GetComponent<BulletScript>();
        bulletScript.damage = damage;
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
        
        
            bullet.transform.position = gameObject.transform.position;
            bullet.transform.rotation = gameObject.transform.rotation;

        if (!isShotgun)
        {
            clone = (GameObject)Instantiate(bullet);
            clone.GetComponent<Rigidbody2D>().velocity = new Vector2(clone.transform.up.y * bulletSpeed, clone.transform.right.y * bulletSpeed);
            DestroyObject(bullet);
            Destroy(clone, 1);
            Vector2 screenPosition = Camera.main.WorldToScreenPoint(clone.transform.position);
            if (screenPosition.y > Screen.height || screenPosition.y < 0)
                Destroy(clone);
        }
        else if (isShotgun)
        {
            for (int i = 0; i < bulletAmount; i++)
            {
                bullet.transform.position = gameObject.transform.position;
                bullet.transform.rotation = gameObject.transform.rotation;

                clone = (GameObject)Instantiate(bullet);
                clone.transform.Rotate(0, 0, ((i - ((bulletAmount / 2)))) * spreadAmount);
                clone.GetComponent<Rigidbody2D>().velocity = new Vector2(clone.transform.up.y * bulletSpeed, clone.transform.right.y * bulletSpeed);
                clone.AddComponent(typeof(BulletScript));
                clone.GetComponent<BoxCollider2D>().enabled = true;
                clone.GetComponent<BulletScript>().enabled = true;
                DestroyObject(bullet);
            }
        }

    }

}
