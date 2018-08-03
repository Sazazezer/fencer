using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideHealthBar : MonoBehaviour {

    public Slider slider;
    private float timeElasped = 0f;

	// Use this for initialization
	void Start () {
		slider.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	public void FlashHealth () {
        Debug.Log("Health flash");
		slider.gameObject.SetActive(true);
        timeElasped = 1f;
	}

    public void Update(){
        timeElasped -=Time.deltaTime;


        if (timeElasped<=0){
            slider.gameObject.SetActive(false);
        }
    }
}
