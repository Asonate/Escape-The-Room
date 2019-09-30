using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PuzzleObject : ClickableObject
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
        PlayerData data = FindObjectOfType<PlayerData>();
        data.playerPos = FindObjectOfType<FirstPersonController>().transform.position;
        data.playerRot = FindObjectOfType<FirstPersonController>().transform.rotation;

        //display textbox

        bool done = false;
        while (!done)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                done = true;
            }
        }

        //hide textbox

        SceneManager.LoadScene(puzzleSceneIndex);
    }
}
