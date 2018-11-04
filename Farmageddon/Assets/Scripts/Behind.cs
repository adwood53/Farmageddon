using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behind : MonoBehaviour {

    public float Dist;
    private Transform trans_form;
    private Transform trans_behind;

	// Use this for initialization
	void Start ()
    {
        trans_form = gameObject.GetComponent<Transform>();
        trans_behind = transform.parent.transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        trans_form.position = new Vector3(trans_behind.position.x, trans_behind.position.y - Dist, 0);
	}
    //Getting object to follow always behind player
    //Look at how camera following player was done earlier that day for positioning
    //Getting ai to chase that point in Destination setter
    //Function to update point that rotates along with the player
}
