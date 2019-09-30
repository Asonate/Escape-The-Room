using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTypes : MonoBehaviour
{
    public Item[] items;

    [System.Serializable]
    public class Item
    {
        public string name;
        public Sprite sprite;
    }
}
