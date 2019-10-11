using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerData : MonoBehaviour
{
    public static bool currentlyInMenu;

    public void Start()
    {
        currentlyInMenu = false;
    }
}
