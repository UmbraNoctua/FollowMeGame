using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;
    public bool transitioning;
    //public int levelProgression;

    
    public Animator transition;

    /*void Start()
    {
        if(firstLevel == true)
        {
            playerPosition.Set(-21.67f, 2.65f);
        }
    }*/

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            //StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + levelProgression));
            StartCoroutine(LoadLevel(sceneToLoad));
            playerStorage.initialValue = playerPosition;
        }
    }
    

        
    IEnumerator LoadLevel(string newScene)
    {
        transitioning = true;

        //Play Animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(1);

        //Load Scene
        SceneManager.LoadScene(newScene);

        //Wait
        yield return new WaitForSeconds(1);

        transitioning = false;

    }

}
