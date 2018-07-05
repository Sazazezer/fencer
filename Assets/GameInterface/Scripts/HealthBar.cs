using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour {

    //private Player player = GameObject.FindObjectOfType<Player>();
    private Slider slider;

    public GameObject player;

    public float health{
        get{
            return player.GetComponent<PlayerStats>().playerHealth;
        }
    }

    public float maxHealth{
        get{
            return player.GetComponent<PlayerStats>().maxPlayerHealth;
        }
    }

	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {

        if (player == null){
            return;
        }

       if (health > 0){
           slider.value = health / maxHealth;
        } else {
            var script = player.GetComponent<Explode>();
            script.OnExplode();
        }
		
	}
}
