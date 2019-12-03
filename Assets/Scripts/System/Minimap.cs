using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Minimap : MonoBehaviour
{
    [SerializeField] Image player;
    [SerializeField] Image[] maps;
    Image activeMap;
    Image previousMap;
    public int activeWorld;
    public FirstPersonController activeController;


    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        Invoke("SetActiveVariables", .25f);
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void SetActiveVariables()
    {
        activeWorld = FindObjectOfType<SceneInformation>().sceneIndex;
        activeController = PlayerData.GetActiveController();
    }

    // Update is called once per frame
    void Update()
    {
        SwapMap();
        SetPosition();
    }

    private void SwapMap()
    {
        if (activeController == null || activeWorld == 0)
        {
            foreach (Image i in maps)
            {
                i.gameObject.SetActive(false);
            }
            return;
        }

        switch (activeWorld)
        {
            case 1:
                if (activeController.transform.position.y >= 101)
                {
                    activeMap = maps[0];
                }
                else
                {
                    activeMap = maps[1];
                }
                break;
            case 2:
                activeMap = maps[2];
                break;
            default:
                //activeMap = null;
                break;
        }
        if (previousMap == null)
        {
            foreach (Image i in maps)
            {
                i.gameObject.SetActive(false);
            }
            activeMap.gameObject.SetActive(true);
        }
        else
        {
            if (previousMap != activeMap)
            {
                foreach (Image i in maps)
                {
                    i.gameObject.SetActive(false);
                }
                activeMap.gameObject.SetActive(true);
            }
        }
    }

    private void SetPosition()
    {
        if (activeController == null || activeWorld == 0)
        {
            player.gameObject.SetActive(false);
            return;
        }
        player.gameObject.SetActive(true);

        switch (activeWorld)
        {
            case 1:
                if (activeController.transform.position.y >= 101)
                {
                    player.transform.localPosition = new Vector3(activeController.transform.localPosition.x, activeController.transform.localPosition.z, 0);
                }
                else
                {
                    player.transform.localPosition = new Vector3(activeController.transform.localPosition.x, activeController.transform.localPosition.z, 0);
                }
                break;
            case 2:
                player.transform.localPosition = new Vector3(activeController.transform.localPosition.z, activeController.transform.localPosition.x, 0);
                break;
            default:
                //activeMap = null;
                break;
        }
    }
}