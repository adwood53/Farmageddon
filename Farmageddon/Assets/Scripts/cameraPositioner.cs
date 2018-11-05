using UnityEngine;
using Cinemachine;

public class cameraPositioner : MonoBehaviour {

 	public float closeness;

	 [SerializeField]public float noiseFrequency;
	 public float frequencyCoolDown;
    public Camera camera;
	public GameObject cursor;
	public GameObject character;
	public GameObject centerPoint;
	public CinemachineVirtualCamera _cinemachine;
	Vector3 point;

	// Use this for initialization
	void Start () {
		point = new Vector3();
		_cinemachine = gameObject.GetComponent<CinemachineVirtualCamera>();
	}
	
	// Update is called once per frame
	void Update () {
		_cinemachine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = noiseFrequency;
		if(noiseFrequency > 0.1)
		{
			noiseFrequency -= frequencyCoolDown;
		}
		else
		{
			noiseFrequency = 0;
		}
        point = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane));
		cursor.transform.position = point;

        centerPoint.transform.position = ((point + (character.transform.position * closeness)) / (closeness + 1));
	}
}
