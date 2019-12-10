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
        yield return new WaitForSeconds(1f);
        Vector3 oldPos = playerMovement.gameObject.transform.localPosition;

        playerMovement.gameObject.transform.localScale = new Vector3(2f, 2f, 2f);
        playerMovement.gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);

        playerMovement.gameObject.SetActive(true);

        yield return new WaitForSecondsRealtime(0.5f);

        playerMovement.CrossFadeAlpha(0f, .5f, true);
        playerMovement.GetComponentInChildren<Text>().CrossFadeAlpha(0f, .5f, true);

        while (playerMovement.gameObject.transform.localScale.x > 0)
        {
            playerMovement.gameObject.transform.localScale -= new Vector3(.025f, .025f, .025f);
            yield return new WaitForSecondsRealtime(.0005f);
        }

        playerMovement.CrossFadeAlpha(1f, .1f, true);
        playerMovement.GetComponentInChildren<Text>().CrossFadeAlpha(1f, .1f, true);

        playerMovement.gameObject.transform.localPosition = new Vector3(oldPos.x - 550, oldPos.y, oldPos.z);
        playerMovement.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);

        while (playerMovement.gameObject.transform.localPosition.x < oldPos.x)
        {
            playerMovement.gameObject.transform.localPosition += new Vector3(10f, 0f, 0f);
            yield return new WaitForSecondsRealtime(.01f);
        }

        yield return WaitForPlayerKey(KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D);

        playerMovement.CrossFadeAlpha(0f, .5f, true);
        playerMovement.GetComponentInChildren<Text>().CrossFadeAlpha(0f, .5f, true);

        for (int i = 0; i < 100; i++)
        {
            playerMovement.gameObject.transform.localPosition += new Vector3(10f, 0f, 0f);
            yield return new WaitForSecondsRealtime(.01f);
        }

        StartCoroutine(GetCameraMovement());
    }

    IEnumerator GetCameraMovement()
    {
        yield return new WaitForSeconds(.5f);

        Vector3 oldPos = cameraMovement.gameObject.transform.localPosition;

        cameraMovement.gameObject.transform.localScale = new Vector3(2f, 2f, 2f);
        cameraMovement.gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);

        cameraMovement.gameObject.SetActive(true);

        yield return new WaitForSecondsRealtime(0.5f);

        cameraMovement.CrossFadeAlpha(0f, .5f, true);
        cameraMovement.GetComponentInChildren<Text>().CrossFadeAlpha(0f, .5f, true);

        while (cameraMovement.gameObject.transform.localScale.x > 0)
        {
            cameraMovement.gameObject.transform.localScale -= new Vector3(.025f, .025f, .025f);
            yield return new WaitForSecondsRealtime(.0005f);
        }

        cameraMovement.CrossFadeAlpha(1f, .1f, true);
        cameraMovement.GetComponentInChildren<Text>().CrossFadeAlpha(1f, .1f, true);

        cameraMovement.gameObject.transform.localPosition = new Vector3(oldPos.x - 550, oldPos.y, oldPos.z);
        cameraMovement.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);

        while (cameraMovement.gameObject.transform.localPosition.x < oldPos.x)
        {
            cameraMovement.gameObject.transform.localPosition += new Vector3(10f, 0f, 0f);
            yield return new WaitForSecondsRealtime(.01f);
        }

        yield return WaitForPlayerMouse();

        cameraMovement.CrossFadeAlpha(0f, .5f, true);
        cameraMovement.GetComponentInChildren<Text>().CrossFadeAlpha(0f, .5f, true);

        for (int i = 0; i < 100; i++)
        {
            cameraMovement.gameObject.transform.localPosition += new Vector3(10f, 0f, 0f);
            yield return new WaitForSecondsRealtime(.01f);
        }

        StartCoroutine(GetRightClick());
    }

    IEnumerator GetRightClick()
    {
        yield return new WaitForSeconds(.5f);

        Vector3 oldPos = right.gameObject.transform.localPosition;

        right.gameObject.transform.localScale = new Vector3(2f, 2f, 2f);
        right.gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);

        right.gameObject.SetActive(true);

        yield return new WaitForSecondsRealtime(0.5f);

        right.CrossFadeAlpha(0f, .5f, true);
        right.GetComponentInChildren<Text>().CrossFadeAlpha(0f, .5f, true);

        while (right.gameObject.transform.localScale.x > 0)
        {
            right.gameObject.transform.localScale -= new Vector3(.025f, .025f, .025f);
            yield return new WaitForSecondsRealtime(.0005f);
        }

        right.CrossFadeAlpha(1f, .1f, true);
        right.GetComponentInChildren<Text>().CrossFadeAlpha(1f, .1f, true);

        right.gameObject.transform.localPosition = new Vector3(oldPos.x - 550, oldPos.y, oldPos.z);
        right.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);

        while (right.gameObject.transform.localPosition.x < oldPos.x)
        {
            right.gameObject.transform.localPosition += new Vector3(10f, 0f, 0f);
            yield return new WaitForSecondsRealtime(.01f);
        }

        yield return WaitForPlayerButton("Fire1");

        right.CrossFadeAlpha(0f, .5f, true);
        right.GetComponentInChildren<Text>().CrossFadeAlpha(0f, .5f, true);

        for (int i = 0; i < 100; i++)
        {
            right.gameObject.transform.localPosition += new Vector3(10f, 0f, 0f);
            yield return new WaitForSecondsRealtime(.01f);
        }

        StartCoroutine(GetLeftClick());
    }

    IEnumerator GetLeftClick()
    {
        yield return new WaitForSeconds(.5f);

        Vector3 oldPos = left.gameObject.transform.localPosition;

        left.gameObject.transform.localScale = new Vector3(2f, 2f, 2f);
        left.gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);

        left.gameObject.SetActive(true);

        yield return new WaitForSecondsRealtime(0.5f);

        left.CrossFadeAlpha(0f, .5f, true);
        left.GetComponentInChildren<Text>().CrossFadeAlpha(0f, .5f, true);

        while (left.gameObject.transform.localScale.x > 0)
        {
            left.gameObject.transform.localScale -= new Vector3(.025f, .025f, .025f);
            yield return new WaitForSecondsRealtime(.0005f);
        }

        left.CrossFadeAlpha(1f, .1f, true);
        left.GetComponentInChildren<Text>().CrossFadeAlpha(1f, .1f, true);

        left.gameObject.transform.localPosition = new Vector3(oldPos.x - 550, oldPos.y, oldPos.z);
        left.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);

        while (left.gameObject.transform.localPosition.x < oldPos.x)
        {
            left.gameObject.transform.localPosition += new Vector3(10f, 0f, 0f);
            yield return new WaitForSecondsRealtime(.01f);
        }

        yield return WaitForPlayerButton("Fire2");

        left.CrossFadeAlpha(0f, .5f, true);
        left.GetComponentInChildren<Text>().CrossFadeAlpha(0f, .5f, true);

        for (int i = 0; i < 100; i++)
        {
            left.gameObject.transform.localPosition += new Vector3(10f, 0f, 0f);
            yield return new WaitForSecondsRealtime(.01f);
        }

        StartCoroutine(GetPauseMenu());
    }

    IEnumerator GetPauseMenu()
    {
        yield return new WaitForSeconds(.5f);

        Vector3 oldPos = pause.gameObject.transform.localPosition;

        pause.gameObject.transform.localScale = new Vector3(2f, 2f, 2f);
        pause.gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);

        pause.gameObject.SetActive(true);

        yield return new WaitForSecondsRealtime(0.5f);

        pause.CrossFadeAlpha(0f, .5f, true);
        pause.GetComponentInChildren<Text>().CrossFadeAlpha(0f, .5f, true);

        while (pause.gameObject.transform.localScale.x > 0)
        {
            pause.gameObject.transform.localScale -= new Vector3(.025f, .025f, .025f);
            yield return new WaitForSecondsRealtime(.0005f);
        }

        pause.CrossFadeAlpha(1f, .1f, true);
        pause.GetComponentInChildren<Text>().CrossFadeAlpha(1f, .1f, true);

        pause.gameObject.transform.localPosition = new Vector3(oldPos.x - 550, oldPos.y, oldPos.z);
        pause.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);

        while (pause.gameObject.transform.localPosition.x < oldPos.x)
        {
            pause.gameObject.transform.localPosition += new Vector3(10f, 0f, 0f);
            yield return new WaitForSecondsRealtime(.01f);
        }

        yield return WaitForPlayerKey(KeyCode.T);

        pause.CrossFadeAlpha(0f, .5f, true);
        pause.GetComponentInChildren<Text>().CrossFadeAlpha(0f, .5f, true);

        for (int i = 0; i < 100; i++)
        {
            pause.gameObject.transform.localPosition += new Vector3(10f, 0f, 0f);
            yield return new WaitForSecondsRealtime(.01f);
        }

        StartCoroutine(GetInventory());
    }

    IEnumerator GetInventory()
    {
        yield return new WaitForSeconds(.5f);

        Vector3 oldPos = inventory.gameObject.transform.localPosition;

        inventory.gameObject.transform.localScale = new Vector3(2f, 2f, 2f);
        inventory.gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);

        inventory.gameObject.SetActive(true);

        yield return new WaitForSecondsRealtime(0.5f);

        inventory.CrossFadeAlpha(0f, .5f, true);
        inventory.GetComponentInChildren<Text>().CrossFadeAlpha(0f, .5f, true);

        while (inventory.gameObject.transform.localScale.x > 0)
        {
            inventory.gameObject.transform.localScale -= new Vector3(.025f, .025f, .025f);
            yield return new WaitForSecondsRealtime(.0005f);
        }

        inventory.CrossFadeAlpha(1f, .1f, true);
        inventory.GetComponentInChildren<Text>().CrossFadeAlpha(1f, .1f, true);

        inventory.gameObject.transform.localPosition = new Vector3(oldPos.x - 550, oldPos.y, oldPos.z);
        inventory.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);

        while (inventory.gameObject.transform.localPosition.x < oldPos.x)
        {
            inventory.gameObject.transform.localPosition += new Vector3(10f, 0f, 0f);
            yield return new WaitForSecondsRealtime(.01f);
        }

        yield return WaitForPlayerKey(KeyCode.R);

        inventory.CrossFadeAlpha(0f, .5f, true);
        inventory.GetComponentInChildren<Text>().CrossFadeAlpha(0f, .5f, true);

        for (int i = 0; i < 100; i++)
        {
            inventory.gameObject.transform.localPosition += new Vector3(10f, 0f, 0f);
            yield return new WaitForSecondsRealtime(.01f);
        }

        yield return new WaitForSeconds(.5f);

        done.gameObject.transform.localScale = new Vector3(2f, 2f, 2f);
        done.gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);

        done.gameObject.SetActive(true);

        yield return new WaitForSecondsRealtime(0.5f);

        done.CrossFadeAlpha(0f, .5f, true);
        done.GetComponentInChildren<Text>().CrossFadeAlpha(0f, .5f, true);

        while (done.gameObject.transform.localScale.x > 0)
        {
            done.gameObject.transform.localScale -= new Vector3(.025f, .025f, .025f);
            yield return new WaitForSecondsRealtime(.0005f);
        }

        yield return new WaitForSecondsRealtime(.1f);
        done.gameObject.SetActive(false);
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