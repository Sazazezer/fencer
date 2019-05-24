﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Yarn.Unity;
using Yarn.Unity.Example;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*Yarn actions
To be used on NPC and other talking object characters to make them do stuff
*/

public class YarnActions : MonoBehaviour {

    IEnumerator NPCMove(GameObject character, GameObject target, float distanceFrom) {
        Debug.Log("Thingie");
        
       // float step = 2;
        // Move our position a step closer to the target.
        Vector3 startPosition = character.transform.position;
        Vector3 targetPosition = target.transform.position;
        while(Vector3.Distance(startPosition,targetPosition)>distanceFrom) {
          //  transform.position = Vector3.MoveTowards(startPosition, targetPosition, 3.0f * Time.deltaTime);
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(target.transform.position.x,target.transform.position.y), 20 * Time.deltaTime);
            Debug.Log(Vector3.Distance(startPosition,targetPosition));
            startPosition = character.transform.position;
            targetPosition = target.transform.position;
            yield return null;
        } 
    }

    IEnumerator EnemyMove(GameObject character, GameObject target, float distanceFrom) {
        Debug.Log("Thingie");
        
       // float step = 2;
        // Move our position a step closer to the target.
        Vector3 startPosition = character.transform.position;
        Vector3 targetPosition = target.transform.position;
        Rigidbody2D body2D = GetComponent<Rigidbody2D> ();
        while(Vector3.Distance(startPosition,targetPosition)>distanceFrom) {
          //  transform.position = Vector3.MoveTowards(startPosition, targetPosition, 3.0f * Time.deltaTime);
        //    body2D.velocity = body2D.MovePosition(startPosition + targetPosition * Time.deltaTime);

          //          // character.GetComponent<MoveForward>().body2D.velocity = new Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(target.transform.position.x,target.transform.position.y), 20 * Time.deltaTime);
            Debug.Log(Vector3.Distance(startPosition,targetPosition));
            startPosition = character.transform.position;
            targetPosition = target.transform.position;
            yield return null;
        } 

    }

    [YarnCommand("explode")]
    public void Explode() {
         Destroy(gameObject);
        // Destroy object
    }

    [YarnCommand("playermove")]
    public void PlayerMove() {
         Destroy(gameObject);
        // Destroy object
    }

    [YarnCommand("npcmovenpc")]
    public void NPCMoveNPC(string destinationName, string stringDistance) {
        Debug.Log("Will i dream?");
        GameObject currObj;
        currObj = GameObject.Find(destinationName);
        float distanceConvert = float.Parse(stringDistance);
        StartCoroutine(EnemyMove(gameObject, currObj, distanceConvert));
    }

  /*  [YarnCommand("enemymove")]
    public void EnemyMove(string destinationName, string stringDistance) {
        Debug.Log("Will i dream?");
        GameObject currObj;
        currObj = GameObject.Find(destinationName);
        float distanceConvert = float.Parse(stringDistance);
        StartCoroutine(EnemyMove(gameObject, currObj, distanceConvert));
    }*/

    [YarnCommand("swipe")]
    public void Swipe() {
         Destroy(gameObject);
        // Destroy object
    }
    [YarnCommand("bossfightnow")]
    public void BossFight() {
            gameObject.GetComponent<BossHealthBar>().FlashHealth();
            gameObject.GetComponent<CharacterActivation>().characterIsActive = true;
    }

    [YarnCommand("bossfightstop")]
    public void StopBossFight() {
            gameObject.GetComponent<BossHealthBar>().FlashHealth();
            gameObject.GetComponent<CharacterActivation>().characterIsActive = false;
            GameObject player = GameObject.Find("Player");
            player.GetComponent<Talk>().preventTalk = 0;
    }

    [YarnCommand("nomoretalk")]
    public void StopTalk(string numberOfBosses) {
    /*    var script = GetComponent<NPC>();
        script.characterName = "aBobe";
        script.talkToNode = "aBobe";
        script.enabled = false;*/
        GameObject player = GameObject.Find("Player");
        player.GetComponent<Talk>().preventTalk += int.Parse(numberOfBosses);
        player.GetComponent<Talk>().canTalk = false; //prevents holding up glitch that causes player to start talking to everyone
        player.GetComponent<Talk>().isTalking = false;
    }

    [YarnCommand("changecamerato")]
    public void ChangeCamera(string newFocus) {
        GameObject focusOn;
        focusOn = GameObject.Find(newFocus);
        GameObject getCamera = GameObject.Find("MainCamera");
        getCamera.GetComponent<CameraFollow>().target = focusOn;
        getCamera.GetComponent<CameraFollow>().Start();
        Debug.Log(getCamera.GetComponent<CameraFollow>().target);
    }

    [YarnCommand("changesceneto")]
    public void ChangeScene(string newScene){
          SceneManager.LoadScene(newScene);
    }

    [YarnCommand("stopmoving")]
    public void StopMovement(){
        Time.timeScale = 0.000001f;
    }

    [YarnCommand("startmoving")]
    public void StartMovement(){
        Time.timeScale = 1f;
    }

    [YarnCommand("addnewjournal")]
    public void YarnAddJournal(string newJournalIndex) {
        int stringIndex = int.Parse(newJournalIndex);
        GameObject.FindObjectOfType<JournalList>().AddNewJournal(stringIndex);
    }

    [YarnCommand("gointojournal")]
    public void GoToJournalEntry(string goToJournalEntry) {
        GameObject.Find("Player").GetComponent<PlayerUIAccess>().switchRestrictionToFalse();
        int stringEntry = int.Parse(goToJournalEntry);
        GameObject[] journalButtons;
        journalButtons = GameObject.FindGameObjectsWithTag("JournalButton");
        
///counting
                    Debug.Log("Count initial buttons");
        for (var j = 0; j < journalButtons.Length; j++){
            Debug.Log(j + ": " + journalButtons[j].GetComponent<ButtonClick>().content);
        }
        Debug.Log("Stop Count. Total: " + journalButtons.Length);
///counting
        int countButtons = 1;
        foreach (GameObject journalButton in journalButtons){
            Debug.Log(countButtons + ": " + journalButton.GetComponent<ButtonClick>().content);
            if (journalButton.GetComponent<ButtonClick>().index == stringEntry){
                Debug.Log("Entry is " + journalButton.GetComponent<ButtonClick>().index + "And button is " + stringEntry + " and countbutton is " + countButtons);
                GameObject.Find("JournalText").GetComponent<Text>().text = journalButton.GetComponent<ButtonClick>().journal;
                GameObject.FindObjectOfType<PlayerUIManager>().InJournal();
                GameObject.FindObjectOfType<JournalList>().HighlightSpecificSlot(stringEntry);
            }
            countButtons++;
        }
        Debug.Log("Into journal i go");

    }

    [YarnCommand("gointopuzzle")]
    public void GoToPuzzleScreen() {
            GameObject.Find("Player").GetComponent<PlayerUIManager>().inPuzzle = true;
            GameObject.Find("Player").GetComponent<PlayerUIAccess>().switchRestrictionToFalse();
            Debug.Log("Hi there");    
            var allPuzzles = new List<PuzzleLock> (FindObjectsOfType<PuzzleLock> ());
            Debug.Log(allPuzzles);
            var target = allPuzzles.Find (delegate (PuzzleLock p) {
                return (p.transform.position - this.transform.position)// is in range?
                .magnitude <= 20;
            });
                Debug.Log(target);
            if (target != null) {
                target.GetComponent<PuzzleLock>().UsePuzzleLock();
            }
    }

    [YarnCommand("checkLock")]
    public bool CheckItemExists(string itemCheck) {
        GameObject lockedItem = GameObject.Find(itemCheck);
        if( lockedItem.GetComponent<DoorLock>().locked == true){
            return true;
        } else {
            return false;
        }
    }
    [YarnCommand("forceSave")]
    public void ForceSave() {
        Debug.Log("ForceSave");
    //    GameObject.FindObjectOfType<DialogueList>().Save();
    }

    [YarnCommand("enableUI")]
    public void EnableUI() {
        GameObject.Find("Player").GetComponent<PlayerUIAccess>().switchRestrictionToFalse();
    }

    [YarnCommand("playsoundeffect")]
    public void YarnPlaySoundEffect(string playSoundEffect) {
       // AudioClip yarnAudio = playSoundEffect;
        var yarnAudio = Resources.Load<AudioClip>("Audio/" + playSoundEffect);
        float yarnAudioVolume = PlayerPrefs.GetFloat("GameSoundEffect",0.5f);
        GameObject.FindGameObjectWithTag("EffectsManager").GetComponent<AudioSource>().PlayOneShot(yarnAudio,yarnAudioVolume);
    }
}
