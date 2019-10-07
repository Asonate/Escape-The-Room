using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleOne : MonoBehaviour
{
    public static int maxCapacity = 10;
    List<Bucket> buckets;

    public static bool firstSelected;
    public static Bucket first;

    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        buckets = FindObjectsOfType<Bucket>().ToList();
        if (buckets != null)
        {
            foreach (Bucket b in buckets)
            {
                if (b.capacity == maxCapacity)
                {
                    b.current = maxCapacity;
                    break;
                }
            }
        }
        foreach (Bucket b in buckets)
            b.UpdateLabel();
    }

    public void CheckAnswer()
    {
        int count = 0;
        foreach (Bucket b in buckets)
        {
            if (b.current == maxCapacity / 2) count++;
        }
        if (count == 2)
        {
            //Display Textbox
            //Load Room again
        }
        else
        {
            //Display Textbox
        }
    }
}
