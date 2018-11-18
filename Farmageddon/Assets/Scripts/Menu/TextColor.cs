using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColor : MonoBehaviour {

	public Color color1;
	public Color color2;
	public float fadeTime = 2;

	private bool active = true;
	private float elapsedTime = 0;
	private Text text;
	private Color colorDifference;
	// Use this for initialization
	void Start () 
	{
		text = gameObject.GetComponent<Text>();
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
				text.color = color2 + (colorDifference * (elapsedTime / fadeTime));
			}
			else
			{
				//swaps from color1 to color2
				text.color = color1 - (colorDifference * (elapsedTime / fadeTime));
			}
		}
	}

	public void SwapColor ()
	{
		elapsedTime = 0;
		active = !active;
	}
}
