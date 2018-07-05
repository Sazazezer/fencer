using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity.Example;
using Yarn.Unity;

public class Talk : AbstractBehaviour {

        public float interactionRadius = 2.0f;
        public bool toggleOptions { get; private set; } 


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
            var canTalk = inputState.GetButtonValue (inputButtons[0]);
            // Remove all player control when we're in dialogue
            if (FindObjectOfType<DialogueRunner>().isDialogueRunning == true) {
                ToggleScripts (!canTalk);
            }

            // Move the player, clamping them to within the boundaries 
            // of the level.




            // Detect if we want to start a conversation
            if (canTalk) {
                toggleOptions = true;
                CheckForNearbyNPC ();
            }

            if(!canTalk){
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
    }
