
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float damage;
    public float screenShake = 10;
    // Update is called once per frame

    void Start()
    {
        Camera.main.GetComponentInChildren<cameraPositioner>().noiseFrequency = screenShake;
        gameObject.GetComponent<Collider2D>().enabled = true;
    }

    void Update () {
        Vector2 screenPositiony = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPositiony.y > Screen.height || screenPositiony.y < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            Destroy(this.gameObject, 3);
        }

        Vector2 screenPositionx = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPositionx.x > Screen.width || screenPositionx.x < 0)
        {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            Destroy(this.gameObject, 3);
        }
            
    }
        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}
