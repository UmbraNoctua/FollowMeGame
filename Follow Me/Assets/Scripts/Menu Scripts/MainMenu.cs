using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public Animator transition;
    public float transitionTime = 1f;


    public void NewJourney ()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        //calls whaterver scene is in the build index exactly after this one.
        //calls transition function LoadLevel below
    }


    IEnumerator LoadLevel(int levelIndex)
    {
        //Play Animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(1);

        //Load Scene
        SceneManager.LoadScene(levelIndex);

    }


    public void QuitGame()
    {
        Debug.Log("QUIT!"); //checks that the quit button is working by printing the word quit
        // in the log
        Application.Quit();
    }
}
