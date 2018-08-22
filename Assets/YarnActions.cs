using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Yarn.Unity;
using Yarn.Unity.Example;

/*Yarn actions
To be used on NPC and other talking object characters to make them do stuff
*/

public class YarnActions : MonoBehaviour {

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
    public void NPCMoveNPC(string destinationName) {

        GameObject currObj;
        currObj = GameObject.Find(destinationName);
        float step = 1 * Time.deltaTime;
        // Move our position a step closer to the target.
        transform.position = Vector3.MoveTowards(transform.position, currObj.transform.position, step);
        Debug.Log("Boop");
         //determine what destination name is
        //confirm destination exists
        //move to destination
          /*  var allParticipants = new List<NPC> (FindObjectsOfType<NPC> ());
            var target = allParticipants.Find(destinationName);
            if (target != null) {
                // Kick off the dialogue at this node.
               // FindObjectOfType<DialogueRunner> ().StartDialogue (target.talkToNode);
                Debug.Log(destinationName);
                Debug.Log(target);
                Debug.Log("I think this works");
             //   body2D.velocity = new Vector2 (target.gameObject.transform.localScale.x * speed, body2D.velocity.y) ;
            }*/
    }

    [YarnCommand("swipe")]
    public void Swipe() {
         Destroy(gameObject);
        // Destroy object
    }
    [YarnCommand("bossfightnow")]
    public void BossFight() {
         Destroy(gameObject);
        // Destroy object
    }
}
