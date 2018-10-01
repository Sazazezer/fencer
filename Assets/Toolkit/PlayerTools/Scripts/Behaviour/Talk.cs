using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity.Example;
using Yarn.Unity;

public class Talk : AbstractBehaviour {

        public float interactionRadius = 2.0f;
        public bool toggleOptions { get; private set; } 
        public bool isTalking = false;
        public bool canTalk = false;
        public MonoBehaviour[] stopScripts;
        public int preventTalk = 0;
        public bool speedUpTalk = false;
        public GameObject gameControl;
    //    private bool stopMotion = false;


        /// Draw the range at which we'll start talking to people.
        void OnDrawGizmosSelected() {
            Gizmos.color = Color.blue;

            // Flatten the sphere into a disk, which looks nicer in 2D games
            Gizmos.matrix = Matrix4x4.TRS(transform.position, Quaternion.identity, new Vector3(1,1,0));

            // Need to draw at position zero because we set position in the line above
            Gizmos.DrawWireSphere(Vector3.zero, interactionRadius);
        }

        void Start(){
            toggleOptions = false;
        }

        /// Update is called once per frame
        void Update () {

            speedUpTalk = inputState.GetButtonValue (inputButtons[0]);

            if (preventTalk <= 0){
                canTalk = inputState.GetButtonValue (inputButtons[0]);
                preventTalk = 0;
            }
          //  stopMotion = FindObjectOfType<DialogueRunner>().isDialogueRunning;
            // Remove all player control when we're in dialogue
            if (FindObjectOfType<DialogueRunner>().isDialogueRunning == true) {
                isTalking = true;
                StopScripts (false);

            } else {
                isTalking = false;
                StopScripts (true);
            }

            // Move the player, clamping them to within the boundaries 
            // of the level.
            
            if (speedUpTalk){
                gameControl.GetComponent<ExampleDialogueUI>().textSpeed = 0f;
            } else {
                gameControl.GetComponent<ExampleDialogueUI>().textSpeed = 0.025f;
            }


            // Detect if we want to start a conversation
            if (canTalk && !isTalking) {
                toggleOptions = true;
                CheckForNearbyNPC ();

            }

            if(FindObjectOfType<DialogueRunner>().isDialogueRunning == false){
                toggleOptions = false;
            }
        }

        /// Find all DialogueParticipants
        /** Filter them to those that have a Yarn start node and are in range; 
         * then start a conversation with the first one
         */
        public void CheckForNearbyNPC ()
        {
            var allParticipants = new List<NPC> (FindObjectsOfType<NPC> ());
            var target = allParticipants.Find (delegate (NPC p) {
                return string.IsNullOrEmpty (p.talkToNode) == false && // has a conversation node?
                (p.transform.position - this.transform.position)// is in range?
                .magnitude <= interactionRadius;
            });
            if (target != null) {
                // Kick off the dialogue at this node.
                FindObjectOfType<DialogueRunner> ().StartDialogue (target.talkToNode);
            }
        }

        protected virtual void StopScripts(bool value){
            foreach(var script in stopScripts){
                script.enabled = value;
            }
        }
    }
