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
    public static List<int> clickedObjects;

    FirstPersonController[] firstPersonControllers;

    private void Awake()
    {
        clickedObjects = new List<int>();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        firstPersonControllers = FindObjectsOfType<FirstPersonController>().OrderBy(m => m.name).ToArray();

        foreach (FirstPersonController f in firstPersonControllers)
        {
            f.gameObject.SetActive(false);
        }

        firstPersonControllers[gamestate].gameObject.SetActive(true);
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void Start()
    {
        currentlyInMenu = false;
    }
}
