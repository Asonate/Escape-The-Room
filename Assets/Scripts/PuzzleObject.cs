using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PuzzleObject : MessageObject
{
    [SerializeField] int puzzleSceneIndex;

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

        PlayerData.playerPos = firstPersonController.transform.position;
        PlayerData.playerRot = firstPersonController.transform.rotation;

        SceneManager.LoadScene(puzzleSceneIndex);

        Destroy(this);
    }
}