using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ActionObject : MessageObject
{
    [SerializeField] int[] requirements;
    FirstPersonController firstPersonController;
    Canvas canvas;
    Image image;
    Text[] texts;

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

        foreach (int i in requirements)
        {
            if (requirementsMet && Inventory.items.Length > i)
            {
                if (Inventory.items[i].amount > 0)
                {
                    requirementsMet = true;
                    yield break;
                }
                requirementsMet = false;
            }
        }

        if (requirementsMet)
        {
            foreach (int i in requirements)
            {
                Inventory.items[i].amount--;
            }

            //execute action

            PlayerData.currentlyInMenu = true;
            yield return StartCoroutine(DisplayMessage());
            PlayerData.currentlyInMenu = false;
        }
        else
        {
            PlayerData.currentlyInMenu = true;
            yield return StartCoroutine(DisplayMessage());
            PlayerData.currentlyInMenu = false;
        }
    }
}
