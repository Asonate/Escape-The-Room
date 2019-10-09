using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PuzzleObject : MessageObject
{
    [SerializeField] int puzzleSceneIndex;
    FirstPersonController firstPersonController;
    Canvas canvas;
    Image image;
    Text[] texts;

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
        PlayerData.playerPos = FindObjectOfType<FirstPersonController>().transform.position;
        PlayerData.playerRot = FindObjectOfType<FirstPersonController>().transform.rotation;

        PlayerData.currentlyInMenu = true;
        yield return StartCoroutine(DisplayMessage());
        PlayerData.currentlyInMenu = false;

        SceneManager.LoadScene(puzzleSceneIndex);
    }
}