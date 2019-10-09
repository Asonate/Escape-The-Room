using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Inventory : MonoBehaviour
{
    public static Item[] items;
    public Item[] itemsSetup;
    [SerializeField] Canvas inventory;
    FirstPersonController firstPersonController;
    public bool currentlyActive;

    [System.Serializable]
    public class Item
    {
        public new string name;
        public int amount;
        public Image image;

        public Item(string name, Image image)
        {
            this.name = name;
            this.amount = 0;
            this.image = image;
        }
    }

    private void Start()
    {
        items = itemsSetup;
        firstPersonController = FindObjectOfType<FirstPersonController>();
        if (firstPersonController)
        {
            firstPersonController.mouseLookEnabled = true;
        }
        inventory.gameObject.SetActive(false);
    }

    void Update()
    {
        if ((currentlyActive && PlayerData.currentlyInMenu) || !PlayerData.currentlyInMenu)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (currentlyActive)
                {
                    DisableInventory();
                }
                else
                {
                    EnableInventory();
                }
            }
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        DisableInventory();
        Start();
    }

    private void EnableInventory()
    {
        inventory.gameObject.SetActive(true);
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

    public void DisableInventory()
    {
        inventory.gameObject.SetActive(false);
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
