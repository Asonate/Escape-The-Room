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
        Destroy(FindObjectOfType<SystemProperties>().gameObject);
        Destroy(FindObjectOfType<NoReload>().gameObject);
        SceneManager.LoadScene("Main");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Start");
    }
}
