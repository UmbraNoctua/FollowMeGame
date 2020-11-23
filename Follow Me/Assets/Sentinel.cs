using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentinel : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        animator.SetBool("charInRange", true);
        Debug.Log("Entered range");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        animator.SetBool("charInRange", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
