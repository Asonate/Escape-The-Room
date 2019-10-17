using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PuzzleObject : MessageObject
{
    [SerializeField] string puzzleName;
    [SerializeField] GameObject[] objectsToRemove;
    [SerializeField] GameObject[] objectsToSpawn;

    int objectIndex;

    private void Awake()
    {
        objectIndex = PlayerData.objectIndex++;
    }

    private void OnEnable()
    {
        if (PlayerData.clickedObjects.Contains(objectIndex))
        {
            Start();
            foreach (GameObject g in objectsToSpawn)
            {
                g.SetActive(true);
            }
            foreach (GameObject g in objectsToRemove)
            {
                g.SetActive(false);
            }
            gameObject.SetActive(false);
            Destroy(this);
        }
        else
        {
            foreach (GameObject g in objectsToSpawn)
            {
                g.SetActive(false);
            }
        }
    }

    public override Color GetColor()
    {
        return Color.magenta;
    }

    public override void Highlight()
    {
        //Play an animation
    }

    public override void Execute()
    {
        if (!PlayerData.currentlyInMenu)
        {
            StartCoroutine(ObjectAction());
        }
    }

    public override IEnumerator ObjectAction()
    {
        PlayerData.currentlyInMenu = true;
        yield return StartCoroutine(DisplayMessage());
        PlayerData.currentlyInMenu = false;

        PlayerData.clickedObjects.Add(objectIndex);

        SceneManager.LoadScene(puzzleName);

        foreach (GameObject g in objectsToSpawn)
        {
            g.SetActive(true);
        }
        foreach (GameObject g in objectsToRemove)
        {
            g.SetActive(false);
        }
        gameObject.SetActive(false);
    }
}