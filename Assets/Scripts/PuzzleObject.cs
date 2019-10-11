using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PuzzleObject : MessageObject
{
    [SerializeField] int puzzleSceneIndex;
    bool canDestroy;

    private void OnEnable()
    {
        if (canDestroy) Destroy(gameObject);
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

        canDestroy = true;
        FindObjectOfType<LoadRoom>().gameObject.SetActive(false);

        SceneManager.LoadScene(puzzleSceneIndex);
    }
}