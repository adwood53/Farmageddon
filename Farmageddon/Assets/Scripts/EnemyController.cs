using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float Health;
    public float outputDamage;
    private float inputDamage;

    // Use this for initialization
    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            inputDamage = collision.gameObject.GetComponent<BulletScript>().damage;
            Health = Health - inputDamage;
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
            Debug.Log(Health);
        }

        if (Health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Dead");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}

