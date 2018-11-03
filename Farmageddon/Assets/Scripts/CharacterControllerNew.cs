using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerNew : MonoBehaviour {

    public Vector2 movement;
    public Vector2 moveAmount;
    public float speed = 1;
    public Vector2 attack;

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        attack.x = Input.GetAxis("Fire1");
        attack.y = Input.GetAxis("Fire2");
    }

    private void Update()
    {
        moveAmount.x = transform.position.x + (movement.x * speed * Time.deltaTime);
        moveAmount.y = transform.position.y + (movement.y * speed * Time.deltaTime);
        transform.position = new Vector3(moveAmount.x, moveAmount.y, transform.position.z);
    }
}
