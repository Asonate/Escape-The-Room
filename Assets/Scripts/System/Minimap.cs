using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Minimap : MonoBehaviour
{
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

    private void SetActiveVariables()
    {
        activeWorld = FindObjectOfType<SceneInformation>().sceneIndex;
        activeController = PlayerData.GetActiveController();
    }

    // Update is called once per frame
    void Update()
    {
        if(activeController == null || activeWorld == 0)
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
        if(previousMap != activeMap)
            {
                foreach(Image i in maps)
                {
                    i.gameObject.SetActive(false);
                }
                activeMap.gameObject.SetActive(true);
            }
        }
    }
}
