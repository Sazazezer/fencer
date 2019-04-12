using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollMovement : MonoBehaviour {

    Scrollbar bar;
    public Canvas journalCanvas;
    public float scrollValue;
 
    public IEnumerator Start()
    {
        yield return null; // Waiting just one frame is probably good enough, yield return null does that
        bar = GetComponentInChildren<Scrollbar>();
        bar.value = 1;
    }

    void Update() {
    if (journalCanvas.GetComponent<JournalCanvas>().panelSelected == 1){
             if (Input.GetButtonDown("Down")) {
                 bar.value += 0.01f;
             } else if (Input.GetButtonDown("Up")) {
                 bar.value -= 0.01f;
             }
        }
    }

    public void ResetScrollbar(){
        bar.value = 1;
    }
}
