using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonController : MonoBehaviour {

    private Transform Demon;
    public Transform Target;

    public float Dist;
    private float yDis;
    private float xDis;

    // Use this for initialization
    void Start ()
    {
        Demon = gameObject.GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        yDis = Mathf.Abs(Target.position.y - Demon.position.y);
        xDis = Mathf.Abs(Target.position.x - Demon.position.x);

        if (yDis < Dist && xDis < Dist)
        {
            gameObject.GetComponent<Pathfinding.AIPath>().enabled = false;
        }

        else
        {
            gameObject.GetComponent<Pathfinding.AIPath>().enabled = true;
        }
	}
}

//if demon position == target.position +- 3