using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TunnelRespawn : MonoBehaviour
{
    public Transform playerPosition;
    public Vector2 originalPosition;
    public bool respawning;
    //public int levelProgression;
    
    public Animator transition;
    public string startNode = "";
    [Header("Optional")]
    public YarnProgram dialogueScript;


    /*void Start()
    {
        if(firstLevel == true)
        {
            playerPosition.Set(-21.67f, 2.65f);
        }
    }*/

    void Start()
    {
        Vector2 originalPosition = new Vector2(-21.67f, 2.65f);
        Debug.Log("Position:" + originalPosition);
        if (dialogueScript != null)
        {
            GameManager.instance.AddDialogue(dialogueScript);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            //StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + levelProgression));
            StartCoroutine(Respawn());
            
        }
    }
    

        
    IEnumerator Respawn()
    {
        respawning = true;

        //Play Animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(0.2f);

        Debug.Log(originalPosition);

        playerPosition.position = new Vector2(-21.67f, 2.65f);;

        //Wait
        yield return new WaitForSeconds(0.3f);

        respawning = false;
        
        // Kick off the dialogue at this node.
        GameManager.instance.StartDialogue(startNode);

    }

}
