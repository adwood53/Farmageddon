
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float damage;
    // Update is called once per frame
    void Update () {
        Vector2 screenPositiony = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPositiony.y > Screen.height || screenPositiony.y < 0)
            Destroy(this.gameObject);

        Vector2 screenPositionx = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPositionx.x > Screen.width || screenPositionx.x < 0)
            Destroy(this.gameObject);
    }
}
