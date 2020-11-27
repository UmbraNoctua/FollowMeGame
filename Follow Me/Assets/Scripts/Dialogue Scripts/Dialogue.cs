using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Dialogue : MonoBehaviour
{
    public string startNode = "";
    private DialogueRunner dialogue;
    

    [Header("Optional")]
    public YarnProgram dialogueScript;

    void Start()
    {
        dialogue = FindObjectOfType<DialogueRunner>();
        if (dialogueScript != null)
        {
            GameManager.instance.AddDialogue(dialogueScript);
        }
    }

    public void StartDialogue()
    {
        // Kick off the dialogue at this node.
        GameManager.instance.StartDialogue(startNode);
        dialogue.IsDialogueRunning = true;
        Debug.Log(dialogue.IsDialogueRunning);
    }
}