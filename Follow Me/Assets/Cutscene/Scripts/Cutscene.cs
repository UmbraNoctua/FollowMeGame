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
        StartCoroutine(DisableSelf());
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            gameObject.SetActive(false); //destroy immediately
        }
    }

     IEnumerator DisableSelf()
    {
       
        yield return new WaitForSeconds(cutSceneTime);

        gameObject.SetActive(false);

    }
}
