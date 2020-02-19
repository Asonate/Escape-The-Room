using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickableField : MonoBehaviour
{
    [SerializeField] int puzzleId;
    [SerializeField] Canvas puzzle;

    [SerializeField] Canvas canvas;
    [SerializeField] Image image;
    [SerializeField] Text[] texts;

    // Start is called before the first frame update
    public void Start()
    {
        HideText();
    }

    public void ExitPuzzle()
    {
        PlayerData.currentlyInPuzzle = false;
        ShowText();
        puzzle.gameObject.SetActive(false);
    }

    public void SkipPuzzle()
    {
        PlayerData.puzzlesCleared[puzzleId] = true;
        PlayerData.currentlyInPuzzle = false;
        ShowText();
        puzzle.gameObject.SetActive(false);
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
            foreach (ClickableField c in FindObjectsOfType<ClickableField>())
            {
                c.HideText();
            }

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
