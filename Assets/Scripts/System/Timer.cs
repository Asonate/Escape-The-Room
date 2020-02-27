using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Timer : MonoBehaviour
{
    [SerializeField] int time;
    [SerializeField] Text text;
    [SerializeField] Text smallText;
    int smallTime;

    [SerializeField] FirstPersonController player;

    [SerializeField] Canvas canvas;
    [SerializeField] Image image;
    [SerializeField] Text[] texts;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Countdown());
    }


    private IEnumerator Countdown()
    {
        while(time >= 0)
        {
            text.text = time.ToString();
            smallTime = 999;
            while (smallTime >= 0)
            {
                smallText.text = smallTime.ToString("D3");
                smallTime--;
                yield return new WaitForSecondsRealtime(0.01f);
            }
            time--;
        }
        StartCoroutine(ObjectAction());
    }

    public virtual IEnumerator ObjectAction()
    {
        PlayerData.currentlyInMenu = true;
        yield return DisplayMessage(texts);
        PlayerData.currentlyInMenu = false;
        SceneManager.LoadScene("Start");
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
