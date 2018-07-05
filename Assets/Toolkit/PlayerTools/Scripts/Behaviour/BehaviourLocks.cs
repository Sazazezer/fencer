using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//controls the locking and unlocking of behaviours

public class BehaviourLocks : AbstractBehaviour {


 public bool WallStick { get { return wallStick; } private set { wallStick = value; } }
 [SerializeField]
 private bool wallStick = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
