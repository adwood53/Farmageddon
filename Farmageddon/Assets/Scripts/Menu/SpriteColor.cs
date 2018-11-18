using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteColor : MonoBehaviour {

	public Color color1;
	public Color color2;
	public float fadeTime = 2;

	private bool active = true;
	private float elapsedTime = 0;
	private SpriteRenderer image;
	private Color colorDifference;
	// Use this for initialization
	void Start () 
	{
		image = gameObject.GetComponent<SpriteRenderer>();
		elapsedTime = fadeTime;	
	}
	
	// Update is called once per frame
	void Update () 
	{
		colorDifference = color1 - color2;
		if(elapsedTime <= fadeTime)
		{
			elapsedTime += Time.deltaTime;

			if(active)
			{
				//swaps from color2 to color1
				image.color = color2 + (colorDifference * (elapsedTime / fadeTime));
			}
			else
			{
				//swaps from color1 to color2
				image.color = color1 - (colorDifference * (elapsedTime / fadeTime));
			}
		}
	}

	public void SwapColor ()
	{
		elapsedTime = 0;
		active = !active;
	}
}
