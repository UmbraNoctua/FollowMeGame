using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GAD375.Prototyper;

public class MonsterController : MonoBehaviour
{
    enum MonsterState
    {
        IDLE,
        CHARGING,
        RESTING,
        STUNNED,
        SCARED
    }

    public Transform player;
    public float moveSpeed = 5f;
    public float distUntilRest = 3.0f;
    public float restTime = 2.0f;
    public float stunnedTime = 2.0f;

    private Rigidbody2D rb;
    private MonsterState state;
    private Vector2 destination;
    private Animator anim;
    private float distanceTravelled;
    private float restTimer = 0.0f;
    private float stunnedTimer = 0.0f;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    void Update()
    {
        if (state == MonsterState.CHARGING)
        {
            if (distanceTravelled >= distUntilRest )
            {
                Rest();
            }
        }
        if (state == MonsterState.RESTING)
        {
            restTimer += Time.deltaTime;
            if (restTimer > restTime)
            {
                Idle();
            }
        }
        if (state == MonsterState.STUNNED)
        {
            stunnedTimer += Time.deltaTime;
            if (stunnedTimer > stunnedTime)
            {
                Idle();
            }
        }
    }

    public void Idle()
    {
        state = MonsterState.IDLE;
        restTimer = 0.0f;
        distanceTravelled = 0.0f;
        stunnedTimer = 0.0f;
        anim.Play("Monster_Idle");
    }

    public void Charge(Vector2 position)
    {
        distanceTravelled = 0.0f;
        destination = position;
        state = MonsterState.CHARGING;
    }

    public void Rest()
    {
        state = MonsterState.RESTING;
        restTimer = 0.0f;
    }

    public void Stunned()
    {
        state = MonsterState.STUNNED;
        stunnedTimer = 0.0f;
        anim.Play("Monster_Dazed");
    }

    private void FixedUpdate()
    {
        if (state == MonsterState.CHARGING)
        {
            if (distanceTravelled < distUntilRest)
            {
                Vector2 direction = destination - (Vector2)transform.position;
                direction.Normalize();
                moveCharacter(direction);
            }
            else
            {
                Stunned();
            }
        }
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
        else if (col.collider.tag == "PickUp") //rocks are tagged with pickup
        {
            GameObject rock = col.collider.gameObject;
            Destroy(rock);
            Charge(player.position);
        }
        else if (col.collider.tag == "Log")
        {
            if (state == MonsterState.CHARGING)
            {
                GameObject log = col.collider.gameObject;
                Destroy(log);
                Rest();
                //disable my collider
                //GetComponent<Collider2D>().enabled = false;
                rb.isKinematic = true;
                rb.velocity = Vector2.zero;
                //now move!
                GetComponent<ObjectMover>().MoveObject("monster_fight_end");
            }
        }
        else
        {
            Stunned();
        }
    }
}
