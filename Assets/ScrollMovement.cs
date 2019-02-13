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
             if (Input.GetKeyDown(KeyCode.DownArrow)) {
                 bar.value += 0.1f;
             } else if (Input.GetKeyDown(KeyCode.UpArrow)) {
                 bar.value -= 0.1f;
             }
        }
    }

    public void ResetScrollbar(){
        bar.value = 1;
    }
}
