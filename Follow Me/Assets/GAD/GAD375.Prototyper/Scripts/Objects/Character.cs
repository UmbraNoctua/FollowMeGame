using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Yarn.Unity;

namespace GAD375.Prototyper
{
    public class Character : MonoBehaviour
    {
        public TMP_Text nameText;
        public string characterName;
        public string[] inventory;

        [Header("Optional Dialogue")]
        public YarnProgram scriptToLoad;
        public string startNode = "";

        private DialogueRunner dialogueRunner;
        
        void Awake()
        {
            dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        }
        // Start is called before the first frame update
        void Start()
        {
            if (scriptToLoad != null) 
            {
                dialogueRunner.Add(scriptToLoad);                
            }
            if (nameText != null)
                nameText.text = characterName;
        }
    }
}