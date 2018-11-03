using UnityEngine;

public class cameraPositioner : MonoBehaviour {

 	public float closeness;
    private Camera camera;
	public GameObject cursor;
	public GameObject character;
	public GameObject centerPoint;
	Vector3 point;

	// Use this for initialization
	void Start () {
		camera = Camera.main;
		point = new Vector3();
	}
	
	// Update is called once per frame
	void Update () {

        point = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane));
		cursor.transform.position = point;

		centerPoint.transform.position = (point + character.transform.position) *  new Vector2(closeness, closeness);
	}
}
