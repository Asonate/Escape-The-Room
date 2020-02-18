using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseEventHandler : MonoBehaviour
{
    public void ResumeGame()
    {
        FindObjectOfType<PauseMenu>().DisablePauseMenu();
    }

    public void RestartGame()
    {
        FindObjectOfType<PlayerData>().ResetData();
        SceneManager.LoadScene("Main New");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Start");
    }
}
