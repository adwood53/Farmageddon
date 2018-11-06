using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
public class GunWeapon : ScriptableObject
{

    public Sprite gunWeapon;
    public Sprite gameBullet;

    public uint tier;
    public string gunName = "Gun Name";

    public uint damage;
    public float speed;
    public float fireRate;
    public AudioClip fireSound;
    public float screenShake;
    public bool isAutomatic;
    public bool isShotgun;
    [Range(1, 100)] public int bulletAmount = 1;
    [Range(1, 100)] public int spreadAmount = 1;




    void Start()
    {

    }


}