using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAnimation : MonoBehaviour
{
	public GameObject animationtoActivate;
	public GameObject imageToDeactivate;
	public int doorShadow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        doorShadow = PlayerPrefs.GetInt("DoorShadow",0);
    }

    void OnTriggerEnter2D(Collider2D col){
		if (doorShadow == 1){
			animationtoActivate.SetActive(true);
			imageToDeactivate.SetActive(false);			
			doorShadow = 2;
			PlayerPrefs.SetInt("DoorShadow",2);
		}

    }
}
