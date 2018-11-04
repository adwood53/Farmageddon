using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour {


    public GameObject cursor;
    public GameObject gunSpawn;
    public GunWeapon currentGunWeapon;

    public float rSpeed = 50;
    private Vector2 direction;
    private float angle;
    private Quaternion rotation;

    private Sprite gunWeapon;
    private Sprite gameBullet;

    public SpriteRenderer spriteRenderer;

    void Start()
    {
        gunWeapon = currentGunWeapon.gunWeapon;
        gameBullet = currentGunWeapon.gameBullet;
        spriteRenderer.sprite = currentGunWeapon.gunWeapon;

        
    }

    private void Update()
    {
        direction = cursor.transform.position - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rSpeed * Time.deltaTime);
    }

}
