using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ActionObject : MessageObject
{
    [SerializeField] Requirement[] requirements;
    [SerializeField] GameObject[] objectsToRemove;
    [SerializeField] GameObject[] objectsToSpawn;
    int objectIndex;

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

    private void Awake()
    {
        objectIndex = PlayerData.objectIndex++;
    }

    private void OnEnable()
    {
        if (PlayerData.clickedObjects.Contains(objectIndex))
        {
            Start();
            foreach (GameObject g in objectsToSpawn)
            {
                g.SetActive(true);
            }
            foreach (GameObject g in objectsToRemove)
            {
                g.SetActive(false);
            }
            gameObject.SetActive(false);
            //Destroy(this);
        }
        else
        {
            foreach (GameObject g in objectsToSpawn)
            {
                g.SetActive(false);
            }
        }
    }

    public override void Start()
    {
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

            canvas = normCanvas;
            image = normImage;
            texts = normTexts;

            PlayerData.clickedObjects.Add(objectIndex);
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

        if (requirementsMet)
        {
            foreach (GameObject g in objectsToSpawn)
            {
                g.SetActive(true);
            }
            foreach (GameObject g in objectsToRemove)
            {
                g.SetActive(false);
            }
            gameObject.SetActive(false);
        }
    }
}
