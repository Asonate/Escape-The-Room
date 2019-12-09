using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoaderEndgame : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LoadMenu()
    {
        try
        {
            FindObjectOfType<PlayerData>().ResetData();
            Destroy(FindObjectOfType<SystemProperties>().gameObject);
            Destroy(FindObjectOfType<NoReload>().gameObject);
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
