using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

    public void FadeMe(){
        StartCoroutine (DoFade());
    }

    IEnumerator DoFade (){
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha>0){
            canvasGroup.alpha -= Time.deltaTime / 2;
            yield return null;
        }
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
        canvasGroup.interactable = false;
        yield return null;
    }
}