using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public Vector3 playerPos = new Vector3(0, 0, 0);
    public Quaternion playerRot = Quaternion.identity;
    public bool currentlyInMenu;
}
