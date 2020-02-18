using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoaderEndgame : MonoBehaviour
{
    private void Start()
    {
        PlayerData.currentlyInMenu = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LoadMenu()
    {
        try
        {
            FindObjectOfType<PlayerData>().ResetData();
        }
        catch
        {
            print("object_not_found");
        }
        SceneManager.LoadScene("Start");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void DisplayCredits()
    {
        //TODO
    }
}
