using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    Transform trans_form;
    Transform trans_man;
    public float dist;
    public float angle = 0;
    public float rotspeed;

	// Use this for initialization
	void Start ()
    {
        trans_form = gameObject.GetComponent<Transform>();
        trans_man = transform.parent.transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        angle += rotspeed;
        trans_form.position = new Vector3(dist * Mathf.Cos(angle) + trans_man.position.x, dist * Mathf.Sin(angle) + trans_man.position.y, 0 );
	}
}
