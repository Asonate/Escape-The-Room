using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheckAnswerFive : MonoBehaviour
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

        Text text = PuzzleFive.CheckAnswer() ? transform.Find("Success Text").GetComponent<Text>() : transform.Find("Failure Text").GetComponent<Text>();

        yield return new WaitForSecondsRealtime(.25f);
        text.gameObject.SetActive(true);
        yield return WaitForPlayerInput();
        text.gameObject.SetActive(false);

        PlayerData.currentlyInMenu = false;

        if (PuzzleFive.CheckAnswer())
        {
            SceneManager.LoadScene("Main 2");
        }
        else
        {
            PuzzleFive.ResetField();
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
