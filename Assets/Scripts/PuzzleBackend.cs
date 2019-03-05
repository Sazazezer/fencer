using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleBackend : MonoBehaviour {

    public string puzzleAnswer;
    public string puzzleGuess;
    public int maxDigits;
    public bool maxDigitedSet = true;
    public int totalDigits = 10;
    public GameObject linkedObject;
    public Text text;
    public AudioClip successSound;
    public AudioClip failureSound;
    private float puzzleVolume = 1f;

    private AudioSource source;
    

    // Use this for initialization
    void Start () {
        GetMaxDigits();
        source = GetComponent<AudioSource>();
    }
    
    // Update is called once per frame
    void Update () {
            text.text = puzzleGuess;

    }

    public void AddNumber(int _selectedNumber){
        if (puzzleGuess.Length == maxDigits){
            Debug.Log("Nope!");
        } else {
            puzzleGuess = puzzleGuess + _selectedNumber.ToString();
            Debug.Log(puzzleGuess); 
           
            }

    }

    public void ClearGuess(){
        puzzleGuess = "";
    }

    public void SubmitGuess(){
        if (puzzleGuess == puzzleAnswer){
            Success();
        } else {
            Failure();
        }
    }

    public void GetMaxDigits(){
        if (maxDigitedSet == true){
            maxDigits = puzzleAnswer.Length; 
        } else {
            maxDigits = totalDigits;
        }
        
        Debug.Log(maxDigits);      
    }

    public void Success(){
        Debug.Log("Yay.Correct.");
        source.PlayOneShot(successSound,puzzleVolume);
        ClearGuess();
        linkedObject.GetComponent<PuzzleLock>().PuzzleUnlock();
    }

    public void Failure(){
        Debug.Log("Boo. Incorrect.");
        source.PlayOneShot(failureSound,puzzleVolume);
        ClearGuess();        
    }
}
