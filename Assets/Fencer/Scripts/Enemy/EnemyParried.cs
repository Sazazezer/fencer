using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParried : EnemyState {

    public bool isParried;
    private EnemyBehaviour enemyBehaviour;
    private EnemyDeath enemyDeath;
    private float timeElapsed = 0f;

    protected override void Awake(){
    base.Awake ();
      enemyBehaviour = GetComponent<EnemyBehaviour>();
      enemyDeath = GetComponent<EnemyDeath>();
}

     void OnParried(bool value){
        ToggleScripts (!isParried);
        if (value == false){
           // Debug.Log("Ha!");
            } else {
                Debug.Log("Gah!");
            }
    }


    
    // Update is called once per frame
    public void GetParried () {
        
        Debug.Log("1Egads. ou are skilled");
        if (!isParried){
            isParried = true;
            timeElapsed = 1.5f;
            OnParried(true);
        } 
    }

    void Update(){
        if(timeElapsed != 0){
            timeElapsed -= Time.deltaTime;
        }

        if (timeElapsed <= 0){
            isParried = false;
           OnParried(false);
        }
    }
}
