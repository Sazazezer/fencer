using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

    public bool screenIsDark;

    public void Start(){
        StartCoroutine (DoFade());
    }

    public void FadeMe(){
        StartCoroutine (DoFade());
    }

    IEnumerator DoFade (){
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha>0){
            canvasGroup.alpha -= Time.deltaTime / 2;
            yield return null;
        }
        screenIsDark = false;
        canvasGroup.interactable = false;
        yield return null;
    }

    public void MeFade(){
        StartCoroutine (FadeDo());
    }

    IEnumerator FadeDo (){
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha<1){
            canvasGroup.alpha += Time.deltaTime / 2;
            yield return null;
        }
        screenIsDark = true;
        canvasGroup.interactable = false;
        yield return null;
    }

    public void CutToBlack(){
        StartCoroutine (BlackCut());
    }

    IEnumerator BlackCut (){
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha<1){
            canvasGroup.alpha = 1;
            yield return null;
        }
        screenIsDark = true;
        canvasGroup.interactable = false;
        yield return null;
    }

}