using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemProperties : MonoBehaviour
{
    public static SystemProperties s;

    void Awake()
    {
        if (!s)
        {
            s = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
}
