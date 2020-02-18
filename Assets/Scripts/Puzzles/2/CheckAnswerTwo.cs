using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheckAnswerTwo : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        foreach (Text t in transform.Find("Success Text").GetComponentsInChildren<Text>()) t.gameObject.SetActive(false);
        foreach (Text t in transform.Find("Failure Text").GetComponentsInChildren<Text>()) t.gameObject.SetActive(false);
    }

    public void Execute()
    {
        if (!PlayerData.currentlyInMenu)
        {
            StartCoroutine(DisplayMessage());
        }
    }

    public IEnumerator DisplayMessage()
    {
        PlayerData.currentlyInMenu = true;

        Text text = PuzzleTwo.CheckAnswer() ? transform.Find("Success Text").GetComponent<Text>() : transform.Find("Failure Text").GetComponent<Text>();

        text.gameObject.SetActive(true);
        yield return WaitForPlayerInput();
        text.gameObject.SetActive(false);

        PlayerData.currentlyInMenu = false;

        if (PuzzleTwo.CheckAnswer())
        {
            SceneManager.LoadScene("Main New");
        }
        else
        {
            PuzzleTwo.ResetField();
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
