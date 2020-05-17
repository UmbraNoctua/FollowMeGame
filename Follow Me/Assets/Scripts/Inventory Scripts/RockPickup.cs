using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPickup : MonoBehaviour
{
    public Transform theDest;

    void OnMouseDown()
    {
        GetComponent<Rigidbody2D>().useGravity = false;
        this.transform.position = theDest.position;
        this.transform.parent = GameObject.Find("Destination").transform;
    }

    void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody2D>().useGravity = true;
    }
}

