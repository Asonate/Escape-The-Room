using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleStateObject : DisplayMessageObject
{
    [SerializeField] int requiredItem; //0 for none
    [SerializeField] GameObject[] offStateObjects;
    [SerializeField] GameObject[] onStateObjects;

    [SerializeField] Canvas canvas;
    [SerializeField] Image image;
    [SerializeField] Text[] successOnTexts;
    [SerializeField] Text[] successOffTexts;
    [SerializeField] Text[] failureTexts;

    bool isOn;

    public override void Start()
    {
        canvas.gameObject.SetActive(false);
        image.gameObject.SetActive(false);
        foreach (Text t in successOnTexts) t.gameObject.SetActive(false);
        foreach (Text t in successOffTexts) t.gameObject.SetActive(false);
        foreach (Text t in failureTexts) t.gameObject.SetActive(false);

        foreach (GameObject g in offStateObjects) g.SetActive(true);
        foreach (GameObject g in onStateObjects) g.SetActive(false);
    }

    public override Color GetColor()
    {
        return Color.red;
    }

    public override void Execute()
    {
        if (!PlayerData.currentlyInMenu)
        {
            StartCoroutine(ObjectAction());
        }
    }

    public override IEnumerator ObjectAction()
    {
        if (PlayerData.itemsFound[requiredItem])
        {
            if(isOn)
            {
                PlayerData.currentlyInMenu = true;
                yield return StartCoroutine(DisplayMessage(successOffTexts));
                PlayerData.currentlyInMenu = false;

                foreach (GameObject g in offStateObjects) g.SetActive(true);
                foreach (GameObject g in onStateObjects) g.SetActive(false);
            }
            else
            {
                PlayerData.currentlyInMenu = true;
                yield return StartCoroutine(DisplayMessage(successOnTexts));
                PlayerData.currentlyInMenu = false;

                foreach (GameObject g in offStateObjects) g.SetActive(false);
                foreach (GameObject g in onStateObjects) g.SetActive(true);
            }
            isOn = !isOn;
        }
        else
        {
            PlayerData.currentlyInMenu = true;
            yield return StartCoroutine(DisplayMessage(failureTexts));
            PlayerData.currentlyInMenu = false;
        }
    }
}


