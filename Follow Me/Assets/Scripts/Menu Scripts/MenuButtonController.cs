using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonController : MonoBehaviour
{
    public int index;
    [SerializeField] bool mouse0;
    [SerializeField] int maxIndex;
    public AudioSource audioSource; //calls for an audio source which will be used when player presses the buttons
    // Start is called before the first frame update
    //this script essentially decides what text animation plays, depending on what the player clicks with the mouse
    //might not need this script, as the tutorial shows it is being used by the player when they press the keyboard.
    //we are using a mouse cursor and not the keyboard
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            if (!mouse0)
            {
                if (Input.GetAxis("Vertical") < 0)
                {
                    if (index < maxIndex)
                    {
                        index++;

                    } else
                    {
                        index = 0;
                    }
                } else if (Input.GetAxis("Vertical") > 0)
                {
                    if (index > 0)
                    {
                        index--;
                    }
                }
                else
                {
                    index = maxIndex;
                }

            }
            mouse0 = true;

        }
        else
        {
            mouse0 = false;
        }
    }
}










