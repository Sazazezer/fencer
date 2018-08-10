using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageRemove : MonoBehaviour {

    public float timeToLive = 5f;
    public Text textBox;

	// Use this for initialization
	void Start () {
		textBox.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        timeToLive -= Time.deltaTime;

        if(timeToLive<=0){
            timeToLive = 5f;
            textBox.gameObject.SetActive(false);
        }
		
	}
}
