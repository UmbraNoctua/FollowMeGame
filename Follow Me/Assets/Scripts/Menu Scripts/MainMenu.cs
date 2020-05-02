using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewJourney ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
        //calls the game scene from the build settings, the game scene has an index of 1
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!"); //checks that the quit button is working by printing the word quit
        // in the log
        Application.Quit();
    }
}
