using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class EntryDialogue : MonoBehaviour
{
    public YarnProgram scriptToLoad;

    public DialogueRunner dialogueRunner;

    private GameObject target;
    // Start is called before the first frame update

    private void Awake()
    {
        target = GameObject.FindWithTag("Player");
    }
    void Start()
    {
        dialogueRunner.Add(scriptToLoad);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
