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
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
