using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public float interactionRadius = 2.0f;
    public AudioClip walkAudio;
    public Animator animator; 

    private Vector2 movement;
    private DialogueRunner dialogue;
    private AudioSource audio;
    private RockThrower thrower;
    private bool IsRunning;
    private bool walking;

    public VectorValue startingPosition;
    
    void Start()
    {
        //dialogueManager = gameObject.GetComponent<DialogueManager>();
        dialogue = FindObjectOfType<DialogueRunner>();
        audio = GetComponent<AudioSource>();
        thrower = GetComponent<RockThrower>();
        //GetComponent<GAD375.Prototyper.ObjectMover>().MoveObject("Initial");
        walking = false;
        transform.position = startingPosition.initialValue;
        Debug.Log(startingPosition.initialValue);
    }

    // Update is called once per frame
    void Update()
    {
        //You can only move if you aren't talking
        if (dialogue.IsDialogueRunning == false)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            //Idle Facing Directions
            if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
            {
                animator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
                animator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
            }



            //Only interact while not talking
            if (Input.GetKeyDown(KeyCode.E))
            {
                CheckForNearbyInteractable();
            }
            //Only look for click positions when not talking
            if (Input.GetMouseButtonDown(0)) //0 is left mouse
            {
                Vector2 clickpoint = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
                thrower.ThrowRock(clickpoint);
            }
            {
                animator.SetFloat("Horizontal", movement.x);
                animator.SetFloat("Vertical", movement.y);
                animator.SetFloat("Speed", movement.sqrMagnitude);

            }
        }
        else
        {
            //No movement during dialogue
            movement = Vector2.zero;

        }

        if (movement.magnitude > 0.3f)
        {
            WalkAudio(true);
            walking = true;
        }
        else
        {
            if (walking == true)
            {
                walking = false;
                WalkAudio(false);
            }
        }

        //animator.SetFloat("Horizontal", movement.x);
       // animator.SetFloat("Vertical", movement.y);
       // animator.SetFloat("Speed", movement.sqrMagnitude);

        
    }

    void WalkAudio(bool shouldplay = true)
    {
        if (audio == null)
            return;
        if (shouldplay)
        {
            audio.clip = walkAudio;
            if (!audio.isPlaying)
            {
                audio.loop = true;
                audio.Play();
            }
        }
        else
        {
            audio.loop = false; //this is if they just stopped walking
            audio.Stop();
        }
    }
    void FixedUpdate()
    {
        //So if they get teleported, sync rb position with transform position?
        if ((Vector2)transform.position != (Vector2)rb.position)
        {
            rb.position = transform.position;
        }
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }

    void CheckForNearbyInteractable()
    {
        var allParticipants = new List<Interactable> (FindObjectsOfType<Interactable> ());
        var target = allParticipants.Find (delegate (Interactable p) 
        {
            return p.OnInteract.GetPersistentEventCount() > 0 && // has some interaction defined
            ((p.transform.position - this.transform.position)// is in range?
            .magnitude <= (interactionRadius + p.radius));
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








