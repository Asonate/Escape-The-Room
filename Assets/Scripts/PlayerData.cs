using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static Vector3 playerPos;
    public static Quaternion playerRot;
    public static bool currentlyInMenu;

    public void Start()
    {
    playerPos = new Vector3(0, 0, 0);
    playerRot = Quaternion.identity;
    currentlyInMenu = false;
    }
}
