using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
public class GunWeapon : ScriptableObject {

    public Sprite gunWeapon;
    public Sprite gameBullet;

    public uint tier;
    public string gunName;

    public uint damage;
    public float speed;
    public float fireRate;

    public enum TypeList
    {
        auto,
        semi,
        shotgun,
        autoShotgun
    }

    public TypeList WeaponType; 

    
    void Start()
    {

    }

    void OnBecomeInvisible()
    {
        Destroy(gameBullet);
    }

}
