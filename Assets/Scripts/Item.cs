using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item : MonoBehaviour
{
    public new string name;
    public Sprite sprite;

    public Item(string name, Sprite sprite)
    {
        this.name = name;
        this.sprite = sprite;
    }
}
