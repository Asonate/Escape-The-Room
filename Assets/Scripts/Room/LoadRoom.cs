using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadRoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SetAllActive();
    }

    public void SetAllActive()
    {
        foreach (Transform child in transform.Find("Room"))
        {
                child.gameObject.SetActive(true);
        }
    }
}
