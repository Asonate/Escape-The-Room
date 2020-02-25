using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] FirstPersonController player;
    [SerializeField] Canvas canvas;
    public bool currentlyActive;

    [SerializeField] Image[] items;
    [SerializeField] Text ticketCount;

    [SerializeField] Image[] clues;
    [SerializeField] Image[] blocks;

    private void Start()
    {
        canvas.gameObject.SetActive(false);
    }

    void Update()
    {
        if (((currentlyActive && PlayerData.currentlyInMenu) || !PlayerData.currentlyInMenu) && PlayerData.allowMenu)
        {
            if (Input.GetKeyDown(KeyCode.R))
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
        //Menu
        canvas.gameObject.SetActive(true);
        if (!PlayerData.currentlyInPuzzle)
        {
            player.mouseLookEnabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
        currentlyActive = true;
        PlayerData.currentlyInMenu = true;

        //Inventory
        for(int i = 1; i <= 3; i++)
        {
            if (PlayerData.itemsFound[i]) items[i-1].gameObject.SetActive(false);
        }
        if (PlayerData.countKeplerTickets > 0) {
            items[3].gameObject.SetActive(false);
            ticketCount.text = PlayerData.countKeplerTickets.ToString();
        }

        //Clues
        for (int i = 0; i <= PlayerData.countPuzzlesCleared; i++)
        {
            {
                clues[i].gameObject.SetActive(true);
                blocks[i].gameObject.SetActive(false);
            }
        }
    }

    public void DisablePauseMenu()
    {
        canvas.gameObject.SetActive(false);
        if (!PlayerData.currentlyInPuzzle)
        {
            player.mouseLookEnabled = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
            Time.timeScale = 1;
        }
        currentlyActive = false;
        PlayerData.currentlyInMenu = false;
    }
}
