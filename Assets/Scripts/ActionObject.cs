using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ActionObject : MessageObject
{
    [SerializeField] Requirement[] requirements;
    Canvas normCanvas;
    Image normImage;
    Text[] normTexts;
    Canvas altCanvas;
    Image altImage;
    Text[] altTexts;

    [System.Serializable]
    public class Requirement
    {
        public int index;
        public int amount;
    }

    public override void Start()
    {
        firstPersonController = FindObjectOfType<FirstPersonController>();
        if (firstPersonController)
        {
            firstPersonController.mouseLookEnabled = true;
        }

        normCanvas = gameObject.transform.Find("Textbox Canvas").GetComponent<Canvas>();
        normImage = normCanvas.GetComponentInChildren<Image>(true);
        normTexts = normCanvas.GetComponentsInChildren<Text>(true);

        normCanvas.gameObject.SetActive(false);
        normImage.gameObject.SetActive(false);
        foreach (Text t in normTexts) t.gameObject.SetActive(false);

        altCanvas = gameObject.transform.Find("Alternate Textbox Canvas").GetComponent<Canvas>();
        altImage = altCanvas.GetComponentInChildren<Image>(true);
        altTexts = altCanvas.GetComponentsInChildren<Text>(true);

        altCanvas.gameObject.SetActive(false);
        altImage.gameObject.SetActive(false);
        foreach (Text t in altTexts) t.gameObject.SetActive(false);

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
        if (!PlayerData.currentlyInMenu)
        {
            StartCoroutine(ObjectAction());
        }
    }

    public override IEnumerator ObjectAction()
    {
        bool requirementsMet = true;

        foreach (Requirement r in requirements)
        {
            if (requirementsMet && Inventory.items.Length > r.index)
            {
                if (Inventory.items[r.index].amount >= r.amount)
                {
                    requirementsMet = true;
                }
                else
                {
                    requirementsMet = false;
                }
            }
        }

        if (requirementsMet)
        {
            foreach (Requirement r in requirements)
            {
                Inventory.items[r.index].amount -= r.amount;
            }

            //execute action

            canvas = normCanvas;
            image = normImage;
            texts = normTexts;
        }
        else
        {
            canvas = altCanvas;
            image = altImage;
            texts = altTexts;
        }

        PlayerData.currentlyInMenu = true;
        yield return StartCoroutine(DisplayMessage());
        PlayerData.currentlyInMenu = false;
    }
}
