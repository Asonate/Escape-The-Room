using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : ClickableObject
{
    [SerializeField] Item obtainedItem;

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
        List<Item> tempItems = FindObjectOfType<ItemList>().items;
        tempItems.Add(obtainedItem);

        //display textbox

        bool done = false;
        while (!done)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                done = true;
            }
        }

        //hide textbox
    }
}
