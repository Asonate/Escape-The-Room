using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour
{
    FirstPersonController firstPersonController;
    [SerializeField] Canvas pauseCanvas;
    public bool currentlyActive;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        firstPersonController = FindObjectOfType<FirstPersonController>();
        if (firstPersonController)
        {
            firstPersonController.mouseLookEnabled = true;
        }
        DisablePauseMenu();
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        firstPersonController = FindObjectOfType<FirstPersonController>();
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

    private void EnablePauseMenu()
    {
        pauseCanvas.gameObject.SetActive(true);
        firstPersonController = FindObjectOfType<FirstPersonController>();
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
        firstPersonController = FindObjectOfType<FirstPersonController>();
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
