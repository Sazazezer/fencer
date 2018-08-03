using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour {

    //private Player player = GameObject.FindObjectOfType<Player>();
    private Slider slider;

    public GameObject character;

    public float health{
        get{
            return character.GetComponent<Stats>().health;
        }
    }

    public float maxHealth{
        get{
            return character.GetComponent<Stats>().maxHealth;
        }
    }

	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {

        if (character == null){
            return;
        }

       if (health > 0){
           slider.value = health / maxHealth;
        } else {
            var script = character.GetComponent<Explode>();
            script.OnExplode();
        }

	}
}
