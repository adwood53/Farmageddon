using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSpawner : MonoBehaviour {

    public MeleeScriptable melee;       //Instance of the MeleeScriptable template

    public BoxCollider2D hitbox;        

    public SpriteRenderer spriteRenderer;   //SpriteRenderer to draw the sprite 

    public GameObject target;       //Target for the sprite to turn towards

    public GameObject spriteObject;

    public float speed = 50;        //Speed that the weapon follows the cursor
    Vector2 direction;              // The direction that the weapon points as a vector2
    float angle;                    //The angle the weapon points
    Quaternion rotation;            //The rotation that the weapon undergoes

    Vector2 spriteSize;

    bool aimActive = true;

	// Use this for initialization
	void Start () {
        spriteRenderer.sprite = melee.weaponSprite;     //Sets the sprite
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "enemy")
        {
            Destroy(col.gameObject);
        }
    }

    private void Update()
    {
        while (aimActive)
        {
            direction = target.transform.position - transform.position;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
            //Rotates the weapon towards the cursor

            spriteObject.GetComponent<BoxCollider2D>().size = spriteObject.GetComponent<SpriteRenderer>().size;
        }        
    }

    private void slashAttack()
    {
        aimActive = false;
        transform.Rotate(Vector2.down * Time.deltaTime);
        aimActive = true;
    }

    private void FixedUpdate()
    {
        if(melee.weaponType == MeleeScriptable.typeList.prod)       //Prodders
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Poke Click");
                transform.Translate(new Vector2(melee.range, 0));
                
            }
        }
        else                    //Slashers
        {
            if(Input.GetMouseButtonDown(0))
            {
                Debug.Log("Slash Click");
                slashAttack();
            }
        }
    }
}
