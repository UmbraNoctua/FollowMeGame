using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;


public class DialogueDebug : MonoBehaviour
{
    private DialogueRunner dialogue;
    
    void Start()
    {
        dialogue = FindObjectOfType<DialogueRunner>();
    }

    public void DialogueStop()
    {
        dialogue.IsDialogueRunning = false;
        Debug.Log(dialogue.IsDialogueRunning);
    }

}
