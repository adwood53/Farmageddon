using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Melee", menuName = "Melee")]
public class MeleeScriptable : ScriptableObject {

    public uint weaponTier;
    public string weaponName;

    //public bool isProd;
   // public bool isBash;

    public enum typeList
    {
        prod,
        bash,
        slash
    }

    public typeList weaponType;

    public float damage;
    public float range;
    public float speed;

    public Sprite weaponSprite;

    public GameObject cursor;
}
