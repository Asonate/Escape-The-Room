using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ClickableField : MonoBehaviour
{
    [SerializeField] int puzzleId;
    [SerializeField] Canvas puzzle;

    [SerializeField] FirstPersonController player;
    [SerializeField] Canvas canvas;
    [SerializeField] Image image;
    [SerializeField] Text[] texts;

    bool closePuzzle;

    // Start is called before the first frame update
    public void Start()
    {
        HideText();
    }

    public void ExitPuzzle()
    {
        closePuzzle = true;
        PlayerData.currentlyInPuzzle = false;
        ShowText();
    }

    public void SkipPuzzle()
    {
        closePuzzle = true;
        PlayerData.countPuzzlesCleared++;
        PlayerData.puzzlesCleared[puzzleId] = true;
        PlayerData.currentlyInPuzzle = false;
        ShowText();
    }

    public void HideText()
    {
        canvas.gameObject.SetActive(false);
        image.gameObject.SetActive(false);
        foreach (Text t in texts) { t.gameObject.SetActive(false); }
    }

    public void ShowText()
    {
        if (!PlayerData.currentlyInMenu) {
            StartCoroutine(ObjectAction());
        }
    }

    public virtual IEnumerator ObjectAction()
    {
        yield return DisplayMessage();
    }

    public IEnumerator DisplayMessage()
    {
        PlayerData.currentlyInMenu = true;

        canvas.gameObject.SetActive(true);
        image.gameObject.SetActive(true);

        foreach (Text t in texts)
        {
            t.gameObject.SetActive(true);

            yield return WaitForPlayerInput();

            t.gameObject.SetActive(false);
        }

        canvas.gameObject.SetActive(false);
        image.gameObject.SetActive(false);

        PlayerData.currentlyInMenu = false;

        if(closePuzzle)
        {
            player.mouseLookEnabled = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
            Time.timeScale = 1;

            closePuzzle = false;
            puzzle.gameObject.SetActive(false);
        }
    }

    public IEnumerator WaitForPlayerInput()
    {
        bool done = false;
        while (!done)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
            {
                done = true;
            }
            yield return null;
        }
    }
}
