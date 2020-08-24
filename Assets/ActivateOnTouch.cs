using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnTouch : MonoBehaviour
{
	public int otherChasing;
	public GameObject objectToActivate;
	public GameObject objectToDeactivate;
	public AudioClip suspenseSound;
	public GameObject [] doors;
    // Start is called before the first frame update

    void Start(){
    	otherChasing = PlayerPrefs.GetInt("OtherChasing",0);
    	if(suspenseSound != null){
	    	GetComponent<AudioSource> ().playOnAwake = false;
	        GetComponent<AudioSource> ().clip = suspenseSound;
	    }
    }
	void OnTriggerEnter2D(Collider2D col){
		if (otherChasing == 1){
			ForceLock();
			if(suspenseSound != null){
				GetComponent<AudioSource> ().Play ();
			}
			
			objectToActivate.SetActive(true);
			objectToDeactivate.SetActive(false);
		}
	}

	public void ForceLock(){
		foreach (GameObject door in doors){
			door.GetComponent<DoorLock>().locked = true;			
		}

	}
}
