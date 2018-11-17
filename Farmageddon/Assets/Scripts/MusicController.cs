using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

	public float hp;
	public float volume = 0.5f;
	public AudioSource bass;
	public AudioSource chords;
	public AudioSource motif;
	public AudioSource antiMotif;
	public AudioSource whine;
	public AudioSource drive;
	public AudioSource crunch;

	// Use this for initialization
	void Start () 
	{
		chords.volume = volume;
		drive.volume = volume;
		bass.volume = 0;
		motif.volume = 0;
		antiMotif.volume = 0;
		whine.volume = 0;
		crunch.volume = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Time.frameCount >30)
		{
			if(hp < 1) bass.volume = volume;
			else bass.volume = 0;
			if(hp <= 0.8) antiMotif.volume = volume;
			else antiMotif.volume = 0;
			if(hp <= 0.5) motif.volume = volume;
			else motif.volume = 0;
			if(hp <= 0.7) crunch.volume = volume;
			else crunch.volume = 0;
			if(hp <= 0.3) whine.volume = volume;
			else whine.volume = 0;
		}
	}
}
