using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public Image xpBar;
	public Image gunSprite;
	public Text weaponName;
	public Text weaponTier;
	public InventoryManager character;
	public float fillAmount = 0;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(character != null)
		{
			if(character.holdingTier > 0)
			{
			fillAmount = (float)character.holdingXP / (((float)character.holdingTier) * (float)character.levelUpAmount);
			}
			xpBar.fillAmount = fillAmount;

			weaponName.text = character.weaps[(int)character.holding].GunName();
			weaponTier.text = character.holdingTier.ToString();
			gunSprite.sprite = character.weaps[(int)character.holding].GunSprite();
		}
		else Debug.Log("Need to Link Character to UI In Inspector!");
	}
}
