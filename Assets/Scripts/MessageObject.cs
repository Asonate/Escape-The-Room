using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageObject : ClickableObject
{
    public override Color GetColor()
    {
        return Color.yellow;
    }

    public override void Highlight()
    {
        //Play an animation
    }

    public override void Execute()
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

        //hide textbox
    }
}
