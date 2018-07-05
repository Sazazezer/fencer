using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public float playerHealth = 50f;
    public float maxPlayerHealth = 100f;




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (playerHealth > maxPlayerHealth){
            playerHealth = maxPlayerHealth;
        }

        if (playerHealth < 0){
            playerHealth = 0;
        }
		
	}

    public void IncreaseHealth(float healthModifier){
        Debug.Log(playerHealth);
        Debug.Log(maxPlayerHealth);
        Debug.Log(healthModifier);
        playerHealth += healthModifier;
        Debug.Log(playerHealth);
        Debug.Log(maxPlayerHealth);
        Debug.Log(healthModifier);
        
    }

    public void DecreaseHealth(float healthModifier){

    playerHealth -= healthModifier;
        
    }
}
