using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

	private bool xpUp = true;      //Whether or not it is possible to gain more XP (Extranious for testing)
	private float lastSwap = 0;    //The time of the last weaponswap (used to stop scrolling too fast)
	private float swapTime = 0;    //The time that must pass before the weapon can be swapped again
	private int[] xps;             //An array for all the XP amounts of the different weapons
	private int[] tiers;           //An array for the tiers of the different weapons

	public GameObject[] weaps; //An array to store the weapons that can be used

	public enum selectedWeapon //A enum to store the weapon types
	{
		Red,
		Green,
		Blue
	};


	public int levelUpAmount;      //How much is added to level up each time
	public selectedWeapon holding; //What weapon is currently being held
	public int holdingTier;        //For displaying the tier of the currently held weapon
	public int holdingXP;          //For displaying the XP of the currently held weapon

	// Use this for initialization
	void Start () 
	{
		xps = new int[3];
		tiers = new int[3];
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Sets the display values to the currently selected values
		holdingXP = xps[(int)holding];
		holdingTier = tiers[(int)holding];

		//Levels up the weapon if it goes over the threshold
		if(holdingXP >= holdingTier * levelUpAmount)
		{
			Debug.Log("Leveling up weapon: " + holding);
			xps[(int)holding] = 0;
			tiers[(int)holding]++;
		}
	}

	public void CycleWeapon(float scroll) //changes weapon
	{
		//Checks if the time is too short to scroll weapons
		if(Time.time - lastSwap > swapTime)
		{
			//Goes through each element in weapons and disables
			int count = 0;
			foreach(GameObject element in weaps)
			{
				weaps[count].SetActive(false);
				count++;
			}
			if(scroll > 0) //if we scroll forwards
			{
				holding++;
				int hold = (int)holding;
				if(hold >= 3) holding = 0;
			}
			else if(scroll < 0) //if we scroll backwards
			{
				holding--;
				int hold = (int)holding;
				if(hold < 0)
				{
					holding = 0;
					holding += 2;
				} 
			}
			//activates the current weapon
			weaps[(int)holding].SetActive(true);
			lastSwap = Time.time;
		}
	}

	public void GainXP()
	{
		if(xpUp)  //extranious for testing
		{
		xps[(int)holding]++;
		xpUp = false;  //extranious for testing
		}
	}

	public void ResetXP()  //extranious for testing
	{
		xpUp = true;  //extranious for testing
	}

	void Upgrade(int tier) //For changing tier (cant implement til have weapon object)
	{

	}
}