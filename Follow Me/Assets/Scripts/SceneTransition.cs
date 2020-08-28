using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;
    //public bool firstLevel;
    public int levelProgression;

    
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
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + levelProgression));
            playerStorage.initialValue = playerPosition;
        }
    }
    

        
    IEnumerator LoadLevel(int levelIndex)
    {

        //Play Animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(1);

        //Load Scene
        SceneManager.LoadScene(levelIndex);

        //Wait
        yield return new WaitForSeconds(1);

    }

}
