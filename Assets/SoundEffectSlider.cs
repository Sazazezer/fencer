using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffectSlider : MonoBehaviour {

    public string buttonSelected;
   // public Text soundEffectSliderSelected;
    public Slider soundEffectSlider;
    public AudioClip testSound;
    private float testVolume = 0.5f;

    private AudioSource source;

    public void Start()
    {
        //Adds a listener to the main slider and invokes a method when the value changes.
        Debug.Log(testVolume);
        Debug.Log(PlayerPrefs.GetFloat("GameSoundEffect",0.5f));
        soundEffectSlider.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
        source = GetComponent<AudioSource>();
        testVolume = PlayerPrefs.GetFloat("GameSoundEffect",0.5f);
        soundEffectSlider.value = testVolume;
        Debug.Log(testVolume);
        Debug.Log(PlayerPrefs.GetFloat("GameSoundEffect",0.5f));
    }

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
  //      soundEffectSliderSelected.text = soundEffectSlider.value.ToString();
        PlayerPrefs.SetFloat("GameSoundEffect", soundEffectSlider.value);
        testVolume = PlayerPrefs.GetFloat("GameSoundEffect");
        if (!source.isPlaying){
            source.PlayOneShot(testSound,testVolume);            
        }

        Debug.Log(soundEffectSlider.value);
    }
}
