using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ActionObject : ClickableObject
{
    [SerializeField] ItemTypes.Item clearItem;
    FirstPersonController firstPersonController;
    Canvas canvas;
    Image image;
    Text[] texts;

    private void Start()
    {
        firstPersonController = FindObjectOfType<FirstPersonController>();
        if (firstPersonController)
        {
            firstPersonController.mouseLookEnabled = true;
        }

        canvas = GetComponentInChildren<Canvas>();
        image = GetComponentInChildren<Image>();
        texts = GetComponentsInChildren<Text>();

        canvas.gameObject.SetActive(false);
        image.gameObject.SetActive(false);
        foreach(Text t in texts) t.gameObject.SetActive(false);
    }

    public override Color GetColor()
    {
        return Color.red;
    }

    public override void Highlight()
    {
        //Play an animation
    }

    public override void Execute()
    {
        if (!FindObjectOfType<PlayerData>().currentlyInMenu)
        {
            StartCoroutine(DisplayMessage());
        }
    }

    private IEnumerator DisplayMessage()
    {
        List<ItemTypes.Item> tempItems = FindObjectOfType<ItemList>().items;

        if (tempItems.Contains(clearItem))
        {
            tempItems.Remove(clearItem);
            //execute action

            FindObjectOfType<PlayerData>().currentlyInMenu = true;

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

            image.gameObject.SetActive(true);
            canvas.gameObject.SetActive(true);

            FindObjectOfType<PlayerData>().currentlyInMenu = false;
        }
        else
        {
            FindObjectOfType<PlayerData>().currentlyInMenu = true;

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

            image.gameObject.SetActive(true);
            canvas.gameObject.SetActive(true);

            FindObjectOfType<PlayerData>().currentlyInMenu = false;
        }
    }

    private IEnumerator WaitForPlayerInput()
    {
        bool done = false;
        while (!done)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
            {
                done = true; // breaks the loop
            }
            yield return null; // wait until next frame, then continue execution from here (loop continues)
        }
    }
}
