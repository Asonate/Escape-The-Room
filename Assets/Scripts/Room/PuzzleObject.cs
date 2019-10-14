using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PuzzleObject : MessageObject
{
    [SerializeField] int puzzleSceneIndex;
    [SerializeField] int objectIndex;

    private void OnEnable()
    {
        if (PlayerData.clickedObjects.Contains(objectIndex))
        {
            Start();
            Destroy(this);
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

        SceneManager.LoadScene(2);
    }
}