using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusButtons : MonoBehaviour
{
    public void loadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void appQuit()
    {
        Application.Quit();
    }

    public void loadCredits()
    {
        SceneManager.LoadScene(2);
    }
    public void loadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
