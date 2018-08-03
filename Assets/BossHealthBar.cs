using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour {

    public Slider slider;
    public Text text;
    public string bossName;
    private CharacterActivation characterActivation;

    // Use this for initialization
    void Start () {
        characterActivation = GetComponent<CharacterActivation>();
        slider.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }
    
    // Update is called once per frame
    public void FlashHealth () {
     //   if(characterActivation.characterIsActive == true){
            slider.gameObject.SetActive(true);
            text.gameObject.SetActive(true);
            text.text = bossName;
      //      }
    }
}
