using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bucket : MonoBehaviour
{
    public Text text;
    public int current = 0;
    public int capacity;
    Vector3 startScale;


    public void Transfer(Bucket b)
    {
        if (this.current > (b.capacity - b.current))
        {
            this.current -= b.capacity - b.current;
            b.current = b.capacity;
        }
        else
        {
            b.current += this.current;
            this.current = 0;
        }
        this.UpdateLabel();
        b.UpdateLabel();
    }

    public void UpdateLabel()
    {
        transform.localScale = new Vector3(startScale.x, (startScale.y / capacity) * current, startScale.z);
        text.text = current.ToString();
    }

    private void Start()
    {
        startScale = new Vector3(0.1f * 7, 0.1f * capacity, 0.1f * capacity);
        Vector3 startPos = transform.position;
        transform.position = new Vector3(startPos.x, startPos.y - (PuzzleOne.maxCapacity * .01f) + (capacity * .01f), startPos.z);
        UpdateLabel();
    }
}

