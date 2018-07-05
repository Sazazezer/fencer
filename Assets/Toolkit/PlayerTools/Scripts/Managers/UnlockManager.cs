using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockManager : MonoBehaviour {

	public int wallStick {get ; private set;}

	void Start(){
		wallStick = PlayerPrefs.GetInt("WallStick");
	}

}
