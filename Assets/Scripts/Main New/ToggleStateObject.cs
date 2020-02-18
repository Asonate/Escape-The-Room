using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ToggleStateObject : InteractionObject
{
    [SerializeField] int requiredItem; //0 for none
    [SerializeField] GameObject[] offStateObjects;
    [SerializeField] GameObject[] onStateObjects;

    [SerializeField] FirstPersonController player;
    [SerializeField] Canvas canvas;
    [SerializeField] Image image;
    [SerializeField] Text[] successOnTexts;
    [SerializeField] Text[] successOffTexts;
    [SerializeField] Text[] failureTexts;

    bool isOn;

    public void Start()
    {
        canvas.gameObject.SetActive(false);
        image.gameObject.SetActive(false);
        foreach (Text t in successOnTexts) t.gameObject.SetActive(false);
        foreach (Text t in successOffTexts) t.gameObject.SetActive(false);
        foreach (Text t in failureTexts) t.gameObject.SetActive(false);

        foreach (GameObject g in offStateObjects) g.SetActive(true);
        foreach (GameObject g in onStateObjects) g.SetActive(false);
    }

    public override Color GetColor()
    {
        return Color.red;
    }

    public override void Execute()
    {
        if (!(PlayerData.currentlyInMenu || PlayerData.currentlyInPuzzle))
        {
            StartCoroutine(ObjectAction());
        }
    }

    public IEnumerator ObjectAction()
    {
        if (PlayerData.itemsFound[requiredItem])
        {
            if (isOn)
            {
                PlayerData.currentlyInMenu = true;
                yield return StartCoroutine(DisplayMessage(successOffTexts));
                PlayerData.currentlyInMenu = false;

                foreach (GameObject g in offStateObjects) g.SetActive(true);
                foreach (GameObject g in onStateObjects) g.SetActive(false);
            }
            else
            {
                PlayerData.currentlyInMenu = true;
                yield return StartCoroutine(DisplayMessage(successOnTexts));
                PlayerData.currentlyInMenu = false;

                foreach (GameObject g in offStateObjects) g.SetActive(false);
                foreach (GameObject g in onStateObjects) g.SetActive(true);
            }
            isOn = !isOn;
        }
        else
        {
            PlayerData.currentlyInMenu = true;
            yield return StartCoroutine(DisplayMessage(failureTexts));
            PlayerData.currentlyInMenu = false;
        }
    }

    public IEnumerator DisplayMessage(Text[] displayText)
    {
        canvas.gameObject.SetActive(true);
        image.gameObject.SetActive(true);

        player.mouseLookEnabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(.025f);

        foreach (Text t in displayText)
        {
            t.gameObject.SetActive(true);

            yield return WaitForPlayerInput();

            t.gameObject.SetActive(false);
        }

        player.mouseLookEnabled = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
        Time.timeScale = 1;

        image.gameObject.SetActive(false);
        canvas.gameObject.SetActive(false);
    }

    public IEnumerator WaitForPlayerInput()
    {
        bool done = false;
        while (!done)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                done = true;
            }
            yield return null;
        }
    }
}