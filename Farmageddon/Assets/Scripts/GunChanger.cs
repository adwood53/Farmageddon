using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunChanger : MonoBehaviour {

	private WeaponSpawner weaponSpawner;
	private ShootController shootController;
	// Use this for initialization
	void Start () 
	{
		weaponSpawner = gameObject.GetComponent<WeaponSpawner>();
		shootController = gameObject.GetComponent<ShootController>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void ChangeGun(GunWeapon gun) //pass it the name of the file you wish to load as a new gun
	{
		weaponSpawner.currentGunWeapon = gun;
		shootController.currentGunWeapon = gun;
	}

	public string GunName()
	{
		string name = weaponSpawner.currentGunWeapon.gunName;
		return name;
	}

	public Sprite GunSprite()
	{
		Sprite sprite = weaponSpawner.currentGunWeapon.gunWeapon;
		return sprite;
	}

	// public void SetActive(bool active)
	// {
	// 	if(active)
	// 	{
	// 		transform.parent
	// 	}
	// }
}
