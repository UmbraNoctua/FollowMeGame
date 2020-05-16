using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity.Example;
using Yarn.Unity;
using GAD375.Prototyper;

namespace GAD375.Prototyper
{
    public class Interaction : MonoBehaviour
    {
        public float interactionRadius = 2.0f;
        private DialogueRunner dialoguerunner;
        private DialogueUI dialogueui;
        private SimpleCharacterController controller;

        void Awake()
        {
            controller = GetComponent<SimpleCharacterController>();
            dialoguerunner = FindObjectOfType<DialogueRunner>();
            dialogueui = FindObjectOfType<DialogueUI>();
        }
        // Start is called before the first frame update
        void Start()
        {
            dialoguerunner.onNodeComplete.AddListener(FinishedNode);
            dialogueui.onDialogueStart.AddListener( StartedDialogue);
            dialogueui.onDialogueEnd.AddListener( FinishedDialogue );
        }

        // Update is called once per frame
        void Update()
        {
            // Detect if we want to start a conversation
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                CheckForNearbyNPC ();
            }
        }

        public void Respawn()
        {
            Checkpoint c = GameManager.instance.currentCheckPoint;
            if (c != null)
            {
                c.Respawn(gameObject);
            }
        }

        /// Find all DialogueParticipants
        /** Filter them to those that have a Yarn start node and are in range; 
            * then start a conversation with the first one
            */
        public void CheckForNearbyNPC ()
        {
            var allParticipants = new List<Character> (FindObjectsOfType<Character> ());
            var target = allParticipants.Find (delegate (Character p) {
                return string.IsNullOrEmpty (p.startNode) == false && // has a conversation node?
                (p.transform.position - this.transform.position)// is in range?
                .magnitude <= interactionRadius;
            });
            if (target != null) 
            {
                // Kick off the dialogue at this node.
                dialoguerunner.StartDialogue(target.startNode);
            }
        }

        public void FinishedNode(string s)
        {
            Debug.Log("Finished node: " + s);
        }
        public void FinishedDialogue()//string s)
        {
            Debug.Log("Finished dialogue "); // + s);
            controller.EnableFPSControls(true);
        }
        public void StartedDialogue()
        {
            Debug.Log("Started Dialogue");
            controller.EnableFPSControls(false);
        }
    }
}
