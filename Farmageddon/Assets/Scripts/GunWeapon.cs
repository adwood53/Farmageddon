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

    public string[] gunType = new string[] { "Auto", "Semi", "Shotgun", "AutoShotgun" };

    

    
    void Start()
    {

    }

    void OnBecomeInvisible()
    {
        Destroy(gameBullet);
    }

}
