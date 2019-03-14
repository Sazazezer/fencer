using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour {

    public string buttonSelected;
  //  public Text volumeSliderSelected;
    public Slider volumeSlider;

    public void Start()
    {
        //Adds a listener to the main slider and invokes a method when the value changes.
        volumeSlider.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
    }

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
      //  volumeSliderSelected.text = volumeSlider.value.ToString();
        PlayerPrefs.SetFloat("GameVolume", volumeSlider.value);
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("GameVolume",0.5f); 
        Debug.Log(volumeSlider.value);
    }
}
