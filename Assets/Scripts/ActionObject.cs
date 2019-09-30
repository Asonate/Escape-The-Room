using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionObject : ClickableObject
{
    [SerializeField] Item clearItem;

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
        List<Item> tempItems = FindObjectOfType<ItemList>().items;

        if (tempItems.Contains(clearItem))
        {
            tempItems.Remove(clearItem);
            //execute action
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
        else
        {
            //display textbox

            bool done = false;
            while (!done)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    done = true;
                }
            }

            //hide textbox        }
        }
    }
}
