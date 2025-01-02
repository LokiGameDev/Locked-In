using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Starting the game
    public void StartGame()
    {
        SceneManager.LoadScene(1);      // Loading the game scene
    }

    // Quiting the game
    public void QuitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();   // Exiting the playmode
        #else
            Application.Quit();                 // Exiting the application
        #endif
    }
}
