using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Dialogue : MonoBehaviour
{
    public string startNode = "";
    

    [Header("Optional")]
    public YarnProgram dialogueScript;

    void Start()
    {
        if (dialogueScript != null)
        {
            GameManager.instance.AddDialogue(dialogueScript);
        }
    }

    public void StartDialogue()
    {
        // Kick off the dialogue at this node.
        GameManager.instance.StartDialogue(startNode);
    }
}