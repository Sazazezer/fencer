using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject target;
	public float scale = 4f;
	public float newY = 0;

	private Transform t;

	void Awake(){
		var cam = GetComponent<Camera> ();
		cam.orthographicSize = (Screen.height / 2f) / scale;
	}

	// Use this for initialization
	public void Start () {
		t = target.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			transform.position = new Vector3 (t.position.x, t.position.y + newY, transform.position.z);
		}
	}
}
