using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ActionObject : ClickableObject
{
    [SerializeField] string[] requirements;
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
        foreach (Text t in texts) t.gameObject.SetActive(false);
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
        bool requirementsMet = true;

        foreach (string s in requirements)
        {
            if (requirementsMet)
            {
                foreach (Item i in FindObjectOfType<Inventory>().items)
                {
                    if (i.name.Equals(s))
                    {
                        requirementsMet = true;
                        break;
                    }
                    requirementsMet = false;
                }
            }
        }

        if (requirementsMet)
        {
            foreach (string s in requirements)
            {
                foreach (Item i in FindObjectOfType<Inventory>().items)
                {
                    if (i.name.Equals(s))
                    {
                        FindObjectOfType<Inventory>().items.Remove(i);
                    }
                }

            }            

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

            image.gameObject.SetActive(false);
            canvas.gameObject.SetActive(false);

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
                done = true;
            }
            yield return null;
        }
    }
}
