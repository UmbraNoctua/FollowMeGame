using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GAD375.Prototyper;

public class MonsterController : MonoBehaviour
{
    enum MonsterState
    {
        
        RESTING,
     
    }

    public Transform player;
    public float moveSpeed = 5f;
    public float distUntilRest = 3.0f;
   

    private Rigidbody2D rb;
    private MonsterState state;
    private Vector2 destination;
    private Animator anim;
    private float distanceTravelled;
    private float restTimer = 0.0f;
    

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }



    public void Rest()
    {
        state = MonsterState.RESTING;
        restTimer = 0.0f;
        //disable my collider
        //GetComponent<Collider2D>().enabled = false;
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
        anim.Play("Monster_Sleeping");
    }

   
    void moveCharacter(Vector2 direction)
    {
        Vector2 movement = direction * moveSpeed * Time.deltaTime; 
        rb.MovePosition((Vector2)transform.position + movement);
        distanceTravelled += movement.magnitude;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Monster collided: " + col.collider.name);
        if (col.collider.tag == "Player")
        {
            //leave the player, their behaviour is handled by the events
        }

        //monster collides with rock they run off.
        else if (col.collider.tag == "PickUp") //rocks are tagged with pickup
        {
            GameObject rock = col.collider.gameObject;
            Destroy(rock);
           
        }
       
    }
}
