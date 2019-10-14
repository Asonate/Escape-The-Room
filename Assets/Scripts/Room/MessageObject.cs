using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class MessageObject : ClickableObject
{
    protected FirstPersonController firstPersonController;
    protected Canvas canvas;
    protected Image image;
    protected Text[] texts;

    public virtual void Start()
    {
        firstPersonController = FindObjectOfType<FirstPersonController>();
        if (firstPersonController)
        {
            firstPersonController.mouseLookEnabled = true;
        }

        HideTextBox();
    }

    protected void HideTextBox()
    {
        canvas = gameObject.transform.Find("Textbox Canvas").GetComponent<Canvas>();
        image = canvas.GetComponentInChildren<Image>(true);
        texts = canvas.GetComponentsInChildren<Text>(true);

        canvas.gameObject.SetActive(false);
        image.gameObject.SetActive(false);
        foreach (Text t in texts) t.gameObject.SetActive(false);
    }

    public override Color GetColor()
    {
        return Color.grey;
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

    public virtual IEnumerator ObjectAction()
    {
        PlayerData.currentlyInMenu = true;
        yield return DisplayMessage();
        PlayerData.currentlyInMenu = false;
    }

    public IEnumerator DisplayMessage()
    {
        canvas.gameObject.SetActive(true);
        image.gameObject.SetActive(true);

        if (firstPersonController)
        {
            firstPersonController.mouseLookEnabled = false;
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;

        foreach (Text t in texts)
        {
            t.gameObject.SetActive(true);

            yield return WaitForPlayerInput();

            t.gameObject.SetActive(false);
        }

        if (firstPersonController)
        {
            firstPersonController.mouseLookEnabled = true;
        }
        if (FindObjectOfType<SceneInformation>().sceneType == SceneType.Room)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
        }
        Time.timeScale = 1;

        image.gameObject.SetActive(false);
        canvas.gameObject.SetActive(false);
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
