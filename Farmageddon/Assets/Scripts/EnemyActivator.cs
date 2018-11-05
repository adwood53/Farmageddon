using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyActivator : MonoBehaviour 
{

	private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Enemy")
		{
			AIDestinationSetter aIDestination = col.gameObject.GetComponent<AIDestinationSetter>();
			aIDestination.enabled = true;
		}
	}
	
}
