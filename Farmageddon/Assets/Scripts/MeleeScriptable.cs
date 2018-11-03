using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Melee", menuName = "Melee")]
public class MeleeScriptable : ScriptableObject {

    public uint weaponTier;
    public string weaponName;

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

    public BoxCollider2D hitbox;

    public GameObject cursor;

    public void pointWeapon()
    {
        
    }

    public void prodAttack()
    {
        
    }

    public void swingAttack()
    {

    }
}
