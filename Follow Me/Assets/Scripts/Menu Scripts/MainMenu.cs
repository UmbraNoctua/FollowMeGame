using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewJourney ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
        //calls whaterver scene is in the build index exactly after this one.
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!"); //checks that the quit button is working by printing the word quit
        // in the log
        Application.Quit();
    }
}
