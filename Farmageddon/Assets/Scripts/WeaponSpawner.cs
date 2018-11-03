using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour {


    public GunWeapon currentGunWeapon;
    public float fireRate;
    public uint damage;
    public float speed;


    private uint tier;
    private uint newTier;
    private Sprite gunWeapon;
    private Sprite gameBullet;

    public Bullet bullet;

    private bool isUpgraded = false; 

    void Start()
    {
        gunWeapon = currentGunWeapon.gunWeapon;
        gameBullet = currentGunWeapon.gameBullet;

        fireRate = currentGunWeapon.fireRate;
        damage = currentGunWeapon.damage;
        speed = currentGunWeapon.speed;

        tier = currentGunWeapon.tier;
    }

    private void Update()
    {
       
    }

    void ChangeWeapon()
    {
    
    }

    void ChangeTier()
    {
        newTier = tier + 1;
        
        if(isUpgraded)
        {
            currentGunWeapon = new GunWeapon
        }

    }

}
