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
            Destroy(FindObjectOfType<SystemProperties>().gameObject);
            Destroy(FindObjectOfType<NoReload>().gameObject);
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

        SceneManager.LoadScene("Main 1");
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
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
