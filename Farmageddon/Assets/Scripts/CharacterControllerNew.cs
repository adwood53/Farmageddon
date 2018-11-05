using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterControllerNew : MonoBehaviour {

    public Vector2 movement;
    public float speed = 1;
    public Vector2 attack;
    public float scroll;

    private float Health = 100;

    private Rigidbody2D rb;
    private InventoryManager im;

    float Damage;

    // Use this for initialization
    void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        im = gameObject.GetComponent<InventoryManager>();
        Damage = GameObject.Find("Zombie").GetComponent<EnemyController>().outputDamage;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        attack.x = Input.GetAxis("Fire1");
        attack.y = Input.GetAxis("Fire2");
        scroll = Input.GetAxisRaw("Mouse ScrollWheel");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Health = Health - Damage;
            Debug.Log(Health);
        }

        if (Health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Dead");
        }
    }

    private void Update()
    {
        rb.velocity = movement * speed;

        if(attack.x > 0) im.GainXP();
        else im.ResetXP();
        if(scroll != 0) im.CycleWeapon(scroll);

        /* OLD MOVEMENT METHOD
        moveAmount.x = transform.position.x + (movement.x * speed * Time.deltaTime);
        moveAmount.y = transform.position.y + (movement.y * speed * Time.deltaTime);
        transform.position = new Vector3(moveAmount.x, moveAmount.y, transform.position.z);
        */
    }
}
