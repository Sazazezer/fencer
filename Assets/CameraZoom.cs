using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
	public float newScale;
	public GameObject player;
	public GameObject camera;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
    	while (camera.GetComponent<CameraFollow>().scale > newScale){
			camera.GetComponent<CameraFollow>().scale = camera.GetComponent<CameraFollow>().scale - 0.1f;
			camera.GetComponent<CameraFollow>().newY = camera.GetComponent<CameraFollow>().newY + 5f;
    		camera.GetComponent<Camera>().orthographicSize = (Screen.height / 2f) / camera.GetComponent<CameraFollow>().scale;
    		Debug.Log(camera.GetComponent<CameraFollow>().scale);
    	}
    	Debug.Log("Finished");
    }
}
