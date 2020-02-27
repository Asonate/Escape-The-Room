using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] int time;
    [SerializeField] Text text;
    [SerializeField] Text smallText;
    int smallTime;

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
        SceneManager.LoadScene("Start");
    }
}
