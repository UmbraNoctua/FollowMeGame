using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    //This needs to be set to just more than the length of the animation.
    public float cutSceneTime = 3.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, cutSceneTime); //destroy after animation is done.
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Destroy(gameObject); //destroy immediately
        }
    }
}
