using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour
{
    FirstPersonController firstPersonController;
    [SerializeField] Canvas pauseCanvas;
    public bool currentlyActive;

    private void Awake()
    {
        if (transform.root.gameObject.GetComponentsInChildren<PauseMenu>(true).Length > 1)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        firstPersonController = FindObjectOfType<FirstPersonController>();
        if (firstPersonController)
        {
            firstPersonController.mouseLookEnabled = true;
        }
        pauseCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        if ((currentlyActive && PlayerData.currentlyInMenu) || !PlayerData.currentlyInMenu)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                if (currentlyActive)
                {
                    DisablePauseMenu();
                }
                else
                {
                    EnablePauseMenu();
                }
            }
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        DisablePauseMenu();
    }

    private void EnablePauseMenu()
    {
        pauseCanvas.gameObject.SetActive(true);
        if (firstPersonController)
        {
            firstPersonController.mouseLookEnabled = false;
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        currentlyActive = true;
        PlayerData.currentlyInMenu = true;
    }

    public void DisablePauseMenu()
    {
        pauseCanvas.gameObject.SetActive(false);
        if (firstPersonController)
        {
            firstPersonController.mouseLookEnabled = true;
        }
        if (FindObjectOfType<SceneInformation>().sceneType == SceneType.Room)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
        }
        Time.timeScale = 1;
        currentlyActive = false;
        PlayerData.currentlyInMenu = false;
    }
}
