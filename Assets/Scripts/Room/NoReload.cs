using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoReload : MonoBehaviour
{
    public static NoReload n;
    public static LoadRoom loadRoom;
    int id;

    void Awake()
    {
        if (!n)
        {
            n = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    private void Start()
    {
        loadRoom = GetComponentInChildren<LoadRoom>(true);
    }
}
