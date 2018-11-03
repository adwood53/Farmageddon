using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSpawner : MonoBehaviour {

    public MeleeScriptable melee;

    public BoxCollider2D hitbox;

	// Use this for initialization
	void Start () {
        hitbox.isTrigger = true;
        hitbox.enabled = false;
	}

    private void FixedUpdate()
    {
        if(melee.weaponType == MeleeScriptable.typeList.prod)
        {
            melee.prodAttack();
        }
        else
        {
            melee.swingAttack();
        }

        melee.pointWeapon();
    }


}
