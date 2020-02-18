using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindItemObject : DisplayMessageObject
{
    [SerializeField] int foundItem;

    [SerializeField] Canvas canvas;
    [SerializeField] Image image;
    [SerializeField] Text[] successTexts;
    [SerializeField] Text[] failureTexts;

    public override void Start()
    {
        canvas.gameObject.SetActive(false);
        image.gameObject.SetActive(false);
        foreach (Text t in successTexts) t.gameObject.SetActive(false);
        foreach (Text t in failureTexts) t.gameObject.SetActive(false);
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
        if (PlayerData.itemsFound[foundItem])
        {
            PlayerData.currentlyInMenu = true;
            yield return StartCoroutine(DisplayMessage(failureTexts));
            PlayerData.currentlyInMenu = false;
        } else
        {
            PlayerData.currentlyInMenu = true;
            yield return StartCoroutine(DisplayMessage(successTexts));
            PlayerData.currentlyInMenu = false;

            PlayerData.itemsFound[foundItem] = true;
        }
    }
}


