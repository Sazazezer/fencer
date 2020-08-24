using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteract : MonoBehaviour
{
	public GameObject exclamation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
    	if (other.tag == "NPC"){
    		exclamation.SetActive(true);
    		Debug.Log("Collision");
    	}

    }
    void OnTriggerExit2D(Collider2D other){
    	if (other.tag == "NPC"){
    		exclamation.SetActive(false);
    		Debug.Log("UnCollision");
    	}

    }
}
