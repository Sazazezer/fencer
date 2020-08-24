using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameImmediateStart : MonoBehaviour
{
	public GameObject areYouSure;
	public bool immediateStart;
    // Start is called before the first frame update
    void Start()
    {
    	if (immediateStart){
    		PlayerPrefs.SetInt("AlItemsCollected",0);
            PlayerPrefs.SetInt("HoleDug", 0);
            PlayerPrefs.SetInt("DigMessages", 0 );
            PlayerPrefs.SetInt("OtherChasing", 0 );
            PlayerPrefs.SetInt("DoorShadow", 0 );
            PlayerPrefs.SetInt("bodyBuried", 0 );
            PlayerPrefs.SetInt("JumpRunTutorial", 0 );
            PlayerPrefs.SetInt("InventJourTutorial", 0 );
            PlayerPrefs.SetInt("DoorsTutorial", 0 );
            PlayerPrefs.SetInt("InspectTut", 0 );
            PlayerPrefs.SetInt("KeysTut", 0 );
 			areYouSure.GetComponent<AreYouSure>().Yes();  

    	} 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
