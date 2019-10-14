using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoReload : MonoBehaviour
{
    public static NoReload n;
    public static LoadRoom loadRoom;

    void Awake()
    {
        if (!n)
        {
            n = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject.transform.parent);
        }
    }

    private void Start()
    {
        loadRoom = GetComponentInChildren<LoadRoom>(true);
    }
}
