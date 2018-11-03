using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour {

    public float fireRate;
    public uint damage;
    public float speed;

    GunWeapon currentGunWeapon;

    void Start()
    {
        fireRate = currentGunWeapon.fireRate;
        damage = currentGunWeapon.damage;
        speed = currentGunWeapon.speed;
    }

}
