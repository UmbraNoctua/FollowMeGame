using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private float distanceTravelled;
    private float restTimer = 0.0f;
    private float stunnedTimer = 0.0f;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        
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
    }

    public void Charge()
    {
        distanceTravelled = 0.0f;
        destination = player.position;
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
    }

    private void FixedUpdate()
    {
        if (state == MonsterState.CHARGING)
        {
            Vector2 direction = destination - (Vector2)transform.position;
            direction.Normalize();
            moveCharacter(direction);
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
    }
}
