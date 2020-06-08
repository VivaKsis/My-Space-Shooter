using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuManager : MonoBehaviour
{
    public string loadGame;
    public void StartGame()
    {
        SceneManager.LoadScene(loadGame);
    }

    public void ExitGame()
    {
        //Application.Quit();
        EditorApplication.isPlaying = false;
    }
}

