using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour

{
    public bool PickUp;
    RaycastHit2D hit;
    public float distance = 2f;
    //public Transform 

    void Start()
    {
        
    }

    void Update()
    {
        //if (Input.GetKeyCode(Mouse0));
        //{
            /*
            if (!PickUp);
            {
                Physics2D.raycastsStartInColliders = false;
                hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x,);
            }

            if(hit.collider!=null)
            {
                PickUp = true;
            }

            */
       //}

        //if(PickUp)
        //    hit.collider.gameObject.transform.position=
    }
     
    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x, distance);
    //}
}

