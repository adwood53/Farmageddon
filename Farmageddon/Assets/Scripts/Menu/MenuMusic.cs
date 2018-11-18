using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour {

	public AudioSource music1;
	public AudioSource music2;
	public float fadeTime = 2;

	private bool active = true;
	private float elapsedTime = 0;
	// Use this for initialization
	void Start () 
	{
		elapsedTime = fadeTime;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(elapsedTime <= fadeTime)
		{
			elapsedTime += Time.deltaTime;

			if(active)
			{
				//swaps from music 2 to music 1
				music1.volume = elapsedTime / fadeTime;
				music2.volume = 1 - music1.volume;
			}
			else
			{
				//swaps from music 1 to music 2
				music2.volume = elapsedTime / fadeTime;
				music1.volume = 1 - music2.volume;
			}
		}
	}

	public void SwapMusic ()
	{
		elapsedTime = 0;
		active = !active;
	}
}
