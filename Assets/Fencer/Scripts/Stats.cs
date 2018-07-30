using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType{
    Sword = 10,
    Spear = 20,
    Dagger = 5
}

public class Stats : MonoBehaviour {

    public float health = 50f;
    public float maxHealth = 100f;
    public float touchDamage = 0f;
    public WeaponType weapon;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (health > maxHealth){
            health = maxHealth;
        }

        if (health < 0){
            health = 0;
        }
		
	}

    public void IncreaseHealth(float healthModifier){
        health += healthModifier;
        Debug.Log("Health increased");
        
    }

    public void DecreaseHealth(float healthModifier){

        health -= healthModifier;
        Debug.Log("Health decreased");
        
    }
}
