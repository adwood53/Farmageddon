using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseCursor : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Cursor.visible = false;	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;
	}
}
