using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] Image playerMovement;
    [SerializeField] Image cameraMovement;
    [SerializeField] Image right;
    [SerializeField] Image left;
    [SerializeField] Image pause;
    [SerializeField] Image inventory;
    [SerializeField] Image done;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement.gameObject.SetActive(false);
        cameraMovement.gameObject.SetActive(false);
        right.gameObject.SetActive(false);
        left.gameObject.SetActive(false);
        pause.gameObject.SetActive(false);
        inventory.gameObject.SetActive(false);
        done.gameObject.SetActive(false);

        StartCoroutine(GetPlayerMovement());
    }

    IEnumerator GetPlayerMovement()
    {
        Vector3 oldPos = playerMovement.gameObject.transform.localPosition;

        playerMovement.gameObject.transform.localPosition = new Vector3(oldPos.x - 525, oldPos.y, oldPos.z);
        playerMovement.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);

        playerMovement.gameObject.SetActive(true);

        while (playerMovement.gameObject.transform.localPosition.x < oldPos.x)
        {
            playerMovement.gameObject.transform.localPosition += new Vector3(10f, 0f, 0f);
            yield return new WaitForSecondsRealtime(.01f);
        }

        yield return WaitForPlayerKey(KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D);

        playerMovement.CrossFadeAlpha(0f, .5f, true);
        playerMovement.GetComponentInChildren<Text>().CrossFadeAlpha(0f, .5f, true);

        for (int i = 0; i < 50; i++)
        {
            playerMovement.gameObject.transform.localPosition += new Vector3(10f, 0f, 0f);
            yield return new WaitForSecondsRealtime(.01f);
        }

        StartCoroutine(GetCameraMovement());
    }

    IEnumerator GetCameraMovement()
    {
        Vector3 oldPos = cameraMovement.gameObject.transform.localPosition;
        
        cameraMovement.gameObject.transform.localPosition = new Vector3(oldPos.x - 525, oldPos.y, oldPos.z);
        cameraMovement.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);

        cameraMovement.gameObject.SetActive(true);

        while (cameraMovement.gameObject.transform.localPosition.x < oldPos.x)
        {
            cameraMovement.gameObject.transform.localPosition += new Vector3(10f, 0f, 0f);
            yield return new WaitForSecondsRealtime(.01f);
        }

        yield return WaitForPlayerMouse();

        cameraMovement.CrossFadeAlpha(0f, .5f, true);
        cameraMovement.GetComponentInChildren<Text>().CrossFadeAlpha(0f, .5f, true);

        for (int i = 0; i < 50; i++)
        {
            cameraMovement.gameObject.transform.localPosition += new Vector3(10f, 0f, 0f);
            yield return new WaitForSecondsRealtime(.01f);
        }

        StartCoroutine(GetRightClick());
    }

    IEnumerator GetRightClick()
    {
        Vector3 oldPos = right.gameObject.transform.localPosition;

        right.gameObject.transform.localPosition = new Vector3(oldPos.x - 525, oldPos.y, oldPos.z);
        right.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);

        right.gameObject.SetActive(true);

        while (right.gameObject.transform.localPosition.x < oldPos.x)
        {
            right.gameObject.transform.localPosition += new Vector3(10f, 0f, 0f);
            yield return new WaitForSecondsRealtime(.01f);
        }

        yield return WaitForPlayerButton("Fire2");

        right.CrossFadeAlpha(0f, .5f, true);
        right.GetComponentInChildren<Text>().CrossFadeAlpha(0f, .5f, true);

        for (int i = 0; i < 50; i++)
        {
            right.gameObject.transform.localPosition += new Vector3(10f, 0f, 0f);
            yield return new WaitForSecondsRealtime(.01f);
        }

        StartCoroutine(GetLeftClick());
    }

    IEnumerator GetLeftClick()
    {
        Vector3 oldPos = left.gameObject.transform.localPosition;

        left.gameObject.transform.localPosition = new Vector3(oldPos.x - 525, oldPos.y, oldPos.z);
        left.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);

        left.gameObject.SetActive(true);

        while (left.gameObject.transform.localPosition.x < oldPos.x)
        {
            left.gameObject.transform.localPosition += new Vector3(10f, 0f, 0f);
            yield return new WaitForSecondsRealtime(.01f);
        }

        yield return WaitForPlayerButton("Fire1");

        left.CrossFadeAlpha(0f, .5f, true);
        left.GetComponentInChildren<Text>().CrossFadeAlpha(0f, .5f, true);

        for (int i = 0; i < 50; i++)
        {
            left.gameObject.transform.localPosition += new Vector3(10f, 0f, 0f);
            yield return new WaitForSecondsRealtime(.01f);
        }

        StartCoroutine(GetPauseMenu());
    }

    IEnumerator GetPauseMenu()
    {
        Vector3 oldPos = pause.gameObject.transform.localPosition;

        pause.gameObject.transform.localPosition = new Vector3(oldPos.x - 525, oldPos.y, oldPos.z);
        pause.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);

        pause.gameObject.SetActive(true);

        while (pause.gameObject.transform.localPosition.x < oldPos.x)
        {
            pause.gameObject.transform.localPosition += new Vector3(10f, 0f, 0f);
            yield return new WaitForSecondsRealtime(.01f);
        }

        yield return WaitForPlayerKey(KeyCode.T);

        pause.CrossFadeAlpha(0f, .5f, true);
        pause.GetComponentInChildren<Text>().CrossFadeAlpha(0f, .5f, true);

        for (int i = 0; i < 50; i++)
        {
            pause.gameObject.transform.localPosition += new Vector3(10f, 0f, 0f);
            yield return new WaitForSecondsRealtime(.01f);
        }

        StartCoroutine(GetInventory());
    }

    IEnumerator GetInventory()
    {
        Vector3 oldPos = inventory.gameObject.transform.localPosition;

        inventory.gameObject.transform.localPosition = new Vector3(oldPos.x - 525, oldPos.y, oldPos.z);
        inventory.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);

        inventory.gameObject.SetActive(true);

        while (inventory.gameObject.transform.localPosition.x < oldPos.x)
        {
            inventory.gameObject.transform.localPosition += new Vector3(10f, 0f, 0f);
            yield return new WaitForSecondsRealtime(.01f);
        }

        yield return WaitForPlayerKey(KeyCode.R);

        inventory.CrossFadeAlpha(0f, .5f, true);
        inventory.GetComponentInChildren<Text>().CrossFadeAlpha(0f, .5f, true);

        for (int i = 0; i < 50; i++)
        {
            inventory.gameObject.transform.localPosition += new Vector3(10f, 0f, 0f);
            yield return new WaitForSecondsRealtime(.01f);
        }

        done.gameObject.transform.localPosition = new Vector3(oldPos.x - 525, oldPos.y, oldPos.z);
        done.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);

        done.gameObject.SetActive(true);

        while (done.gameObject.transform.localPosition.x < oldPos.x)
        {
            done.gameObject.transform.localPosition += new Vector3(10f, 0f, 0f);
            yield return new WaitForSecondsRealtime(.01f);
        }

        yield return new WaitForSecondsRealtime(1f);

        done.CrossFadeAlpha(0f, .5f, true);
        done.GetComponentInChildren<Text>().CrossFadeAlpha(0f, .5f, true);

        for (int i = 0; i < 50; i++)
        {
            done.gameObject.transform.localPosition += new Vector3(10f, 0f, 0f);
            yield return new WaitForSecondsRealtime(.01f);
        }
    }

    IEnumerator WaitForPlayerKey(params KeyCode[] keyCodes)
    {
        bool done = false;
        while (!done)
        {
            foreach (KeyCode k in keyCodes)
            {
                if (Input.GetKeyDown(k))
                {
                    done = true;
                }
            }
            yield return null;
        }
    }

    IEnumerator WaitForPlayerButton(params string[] buttons)
    {
        bool done = false;
        while (!done)
        {
            foreach (string s in buttons)
            {
                if (Input.GetButtonDown(s))
                {
                    done = true;
                }
            }
            yield return null;
        }
    }

    IEnumerator WaitForPlayerMouse()
    {
        bool done = false;
        while (!done)
        {
            {
                if (Math.Abs(Input.GetAxis("Mouse X")) > 0 || Math.Abs(Input.GetAxis("Mouse Y")) > 0)
                {
                    done = true;
                }
            }
            yield return null;
        }

    }
}