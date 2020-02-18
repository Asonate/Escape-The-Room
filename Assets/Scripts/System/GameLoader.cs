using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    private void OnEnable()
    {
        try {
            FindObjectOfType<PlayerData>().ResetData();
        }
        catch
        {
            print("object_not_found");
        }
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LoadGame()
    {

        SceneManager.LoadScene("Main New");
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
