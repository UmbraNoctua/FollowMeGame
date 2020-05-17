using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public float interactionRadius = 2.0f;
   // public Animator animator; *will add later on when we have animations

    private Vector2 movement;
    private DialogueRunner dialogue;
    private bool IsRunning;

    void Start()
    {
        //dialogueManager = gameObject.GetComponent<DialogueManager>();
        dialogue = FindObjectOfType<DialogueRunner>();
        GetComponent<GAD375.Prototyper.ObjectMover>().MoveObject("Initial");
    }
    
    // Update is called once per frame
    void Update()
    {
        //You can only move if you aren't talking
        if (dialogue == null || dialogue.IsDialogueRunning == false)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
        else
        {
            movement = Vector2.zero;
        }

        //animator.SetFloat("Horizontal", movement.x);
       // animator.SetFloat("Vertical", movement.y);
       // animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckForNearbyInteractable();
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void CheckForNearbyInteractable()
    {
        var allParticipants = new List<Interactable> (FindObjectsOfType<Interactable> ());
        var target = allParticipants.Find (delegate (Interactable p) 
        {
            return p.OnInteract.GetPersistentEventCount() > 0 && // has some interaction defined
            ((p.transform.position - this.transform.position)// is in range?
            .magnitude <= interactionRadius) &&
            ((p.transform.position - this.transform.position)
            .magnitude <= p.radius);
        });
        if (target != null) 
        {
            target.Interact(gameObject);
        }
    }

    /*
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                Dialogue dialogue = collision.gameObject.GetComponent<Dialogue>();
                if (dialogue != null)
                {
                    dialogueManager.StartDialogue(dialogue);
                }
            }
        }

    }
    */

}








