using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    Rigidbody2D rb2d;
    Collider2D collider;
    RockThrower rockThrower;
    
    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        rockThrower = FindObjectOfType<RockThrower>();
    }


    public void Throw(Vector2 direction, float strength)
    {
        rb2d.AddForce(direction * strength);
        collider.isTrigger = false;
    }

    public void BePickedUp()
    {
        rockThrower.Pickup(this);
    }
}
