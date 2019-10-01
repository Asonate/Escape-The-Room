using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public Vector3 playerPos;
    public Quaternion playerRot;
    public bool currentlyInMenu;

    public void Start()
    {
    playerPos = new Vector3(0, 0, 0);
    playerRot = Quaternion.identity;
    currentlyInMenu = false;
    }
}
