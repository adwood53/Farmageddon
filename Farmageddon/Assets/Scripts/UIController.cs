using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public Image xpBar;
	public Image healthBar;
	public Image gunSprite;
	public Text weaponName;
	public Text weaponTier;
	public Text healthAmt;
	public GameObject character;
	public float xpFillAmount = 0;
	public float healthFillAmount = 0;
	public GameObject gameOver;

	private InventoryManager inventory;
	private CharacterControllerNew health;
	private float maxHealth = 0; //Automatically detects, no need to set to a value

	// Use this for initialization
	void Start () 
	{
		if(character != null)
		{
			inventory = character.gameObject.GetComponent<InventoryManager>();
			health = character.gameObject.GetComponent<CharacterControllerNew>();
		}
		else
		{
			Debug.Log("Need to link character to UI!!");
		}
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		

		if(inventory != null)
		{
			if(inventory.holdingTier > 0)
			{
			xpFillAmount = (float)inventory.holdingXP / (((float)inventory.holdingTier) * (float)inventory.levelUpAmount);
			}
			xpBar.fillAmount = xpFillAmount;

			weaponName.text = inventory.gunName;
			weaponTier.text = inventory.holdingTier.ToString();
			gunSprite.sprite = inventory.gunSprite;
		}
		else
		{
			xpBar.fillAmount = 0;
		}

		if(health != null)
		{
			if(health.Health > maxHealth) maxHealth = health.Health;
			healthFillAmount = health.Health / maxHealth;
			healthBar.fillAmount = healthFillAmount;
			healthAmt.text = health.Health.ToString();
		}
		else 
		{
			healthBar.fillAmount = 0;
		}

		if(healthBar.fillAmount == 0)
		{
			gameOver.SetActive(true);
		}
	}
}
