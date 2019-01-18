using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideRoom : MonoBehaviour {

   // public float alphaColour;
	// Use this for initialization
	private Renderer renderer;
    private Color newColor;
    private bool roomEntered = false;

    void Awake () {
        renderer = gameObject.GetComponent<Renderer>();
        newColor = renderer.material.color;
        newColor.a = 1f;
        renderer.material.color = newColor;
	}
	
    void OnTriggerEnter2D(Collider2D coll){
        roomEntered = true;
    }

    void Update(){
        if(roomEntered == true){
            newColor = renderer.material.color;
            newColor.a -= 0.1f;
            renderer.material.color = newColor;
                
        }

        if (newColor.a <= 0f){
            Destroy(gameObject);
        }
    }

}
