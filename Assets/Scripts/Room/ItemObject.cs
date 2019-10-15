using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ItemObject : MessageObject
{
    [SerializeField] AddedItem[] addedItems;
    [SerializeField] GameObject[] objectsToRemove;
    [SerializeField] GameObject[] objectsToSpawn;
    int objectIndex;

    [System.Serializable]
    public class AddedItem
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

    public override Color GetColor()
    {
        return Color.blue;
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
        foreach (AddedItem a in addedItems)
        {
            if(Inventory.items.Length > a.index) Inventory.items[a.index].amount += a.amount;
        }

        PlayerData.currentlyInMenu = true;
        yield return StartCoroutine(DisplayMessage());
        PlayerData.currentlyInMenu = false;

        PlayerData.clickedObjects.Add(objectIndex);

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
}
