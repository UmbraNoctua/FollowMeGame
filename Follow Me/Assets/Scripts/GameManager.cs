using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;
    static List<YarnProgram> addedPrograms = new List<YarnProgram>();
    public DialogueRunner dialogueRunner;
    
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    public static GameManager instance
    {
        get {
            return _instance;
        }
    }

    public void StartDialogue(string node)
    {
        dialogueRunner.StartDialogue(node);
    }

    public void AddDialogue(YarnProgram dscript)
    {
        if (!addedPrograms.Contains(dscript))
        {
            dialogueRunner.Add(dscript);
            addedPrograms.Add(dscript);
        }
    }
}
