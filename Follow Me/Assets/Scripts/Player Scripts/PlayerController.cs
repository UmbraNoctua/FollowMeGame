using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    public Animator animator;

    Vector2 movement;

    bool IsRunning;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Awake()
    {
        //running code, allow the player to run by holding shift whilst moving
        if (Input.GetKeyDown(KeyCode.W)) //&& GetKey(KeyCode.LeftShift == true))

        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            IsRunning = true;

        }
        else if (Input.GetKeyDown(KeyCode.W))  //&& GetKey(KeyCode.LeftShift == false))

        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            IsRunning = false;
        } //Running with W key and Shift key




        if (Input.GetKeyDown(KeyCode.A)) //&& GetKey(KeyCode.LeftShift == true))

        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            IsRunning = true;

        }
        else if (Input.GetKeyDown(KeyCode.A)) //&& GetKey(KeyCode.LeftShift == false))

        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            IsRunning = false;


        } //Running with A key and shift key




        if (Input.GetKeyDown(KeyCode.S)) //&& GetKey(KeyCode.LeftShift == true))

        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            IsRunning = true;

        }
        else if (Input.GetKeyDown(KeyCode.S)) //&& GetKey(KeyCode.LeftShift == false))

        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            IsRunning = false;
        } //Running with S key and shift key




        if (Input.GetKeyDown(KeyCode.D)) //&& GetKey(KeyCode.LeftShift == true))

        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            IsRunning = true;

        }
        else if (Input.GetKeyDown(KeyCode.D))  //&& GetKey(KeyCode.LeftShift == false)) this needs to be fixed

        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            IsRunning = false;
        } //Running with D key and shift key
    }
}





