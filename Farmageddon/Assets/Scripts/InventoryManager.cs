using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

	private bool xpUp = true;      //Whether or not it is possible to gain more XP (Extranious for testing)
	private float lastSwap = 0;    //The time of the last weaponswap (used to stop scrolling too fast)
	private float swapTime = 0;    //The time that must pass before the weapon can be swapped again
	private int[] xps;             //An array for all the XP amounts of the different weapons
	private int[] tiers;           //An array for the tiers of the different weapons

	public GunChanger[] weaps; //An array to store the weapons that can be used
	public GunWeapon[] gunList;
	public GunWeapon[,] possibleGuns; //Array for all the possible guns to use

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
		holding = 0;
		xps = new int[3];
		tiers = new int[3] {1,1,1};

		possibleGuns = new GunWeapon[gunList.Length / 3,3];

		//Converts a single array into a multi-dimensional array
		int count = 0;
		for(int i = 0; i < gunList.Length / 3; i++)
		{
			for(int j = 0; j < 3; j++)
			{
				if(gunList[count] != null)
				{
					possibleGuns[i,j] = gunList[count];
					count++;
				}
				else
				{
					//catches exception
					Debug.Log("INVENTORY MANAGER gunList[] conversion fail! Please check number of scriptable object guns is multiple of 3!");
					possibleGuns[i,j] = gunList[0];
					count++;
				}
			}
		}
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
			Upgrade(tiers[(int)holding]); //Gives the tier of the weapon currently being held
		}
	}

	public void CycleWeapon(float scroll) //changes weapon
	{
		//Checks if the time is too short to scroll weapons
		if(Time.time - lastSwap > swapTime)
		{
			//Goes through each element in weapons and disables
			int count = 0;
			foreach(GunChanger element in weaps)
			{
				weaps[count].gameObject.SetActive(false);
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
			weaps[(int)holding].gameObject.SetActive(true);
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
		if(tier > gunList.Length / 3)
		{
			Debug.Log("Out of upgrades for gun!");
		}
		else
		{
			weaps[(int)holding].ChangeGun(possibleGuns[tier-1,Random.Range(0,2)]);
		}
	}
}