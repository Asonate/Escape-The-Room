using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerData : MonoBehaviour
{
    public static bool currentlyInMenu;
    public static int gamestate;
    public static List<int> clickedObjects = new List<int>();
    public static int objectIndex;

    FirstPersonController[] firstPersonControllers;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (FindObjectOfType<SceneInformation>().sceneType == SceneType.Room)
        {
            firstPersonControllers = FindObjectsOfType<FirstPersonController>().OrderBy(m => m.name).ToArray();

            foreach (FirstPersonController f in firstPersonControllers)
            {
                f.gameObject.SetActive(false);
            }

            if(firstPersonControllers.Length >= gamestate) firstPersonControllers[gamestate].gameObject.SetActive(true);
        }
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void ResetData()
    {
        clickedObjects.Clear();
        gamestate = 0;
        currentlyInMenu = false;
    }
}
