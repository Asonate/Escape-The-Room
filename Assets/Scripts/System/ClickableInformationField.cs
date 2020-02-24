using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickableInformationField : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Image textbox;
    [SerializeField] Text[] texts;

    public void Start()
    {
        image.gameObject.SetActive(false);
        textbox.gameObject.SetActive(false);
        foreach (Text t in texts) t.gameObject.SetActive(false);
    }

    public void ExecuteImage()
    {
        if (!PlayerData.clueShown)
        {
            StartCoroutine(DisplayImage());
        }
    }

    public void ExecuteText()
    {
        if (!PlayerData.clueShown)
        {
            StartCoroutine(DisplayMessage());
        }
    }

    public IEnumerator DisplayImage()
    {
        PlayerData.clueShown = true;

        image.gameObject.SetActive(true);

        yield return WaitForPlayerInput();

        yield return DisplayMessage();

        yield return WaitForPlayerInput();

        image.gameObject.SetActive(false);

        PlayerData.clueShown = false;

    }

    public IEnumerator DisplayMessage()
    {
        PlayerData.clueShown = true;

        textbox.gameObject.SetActive(true);

        foreach (Text t in texts)
        {
            t.gameObject.SetActive(true);

            yield return WaitForPlayerInput();

            t.gameObject.SetActive(false);
        }

        textbox.gameObject.SetActive(false);

        PlayerData.clueShown = false;
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