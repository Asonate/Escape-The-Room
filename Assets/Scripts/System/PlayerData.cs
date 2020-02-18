using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerData : MonoBehaviour
{
    public static bool currentlyInMenu;
    public static bool currentlyInPuzzle;

    public static bool[] itemsFound = { true, false, false, false };

    public static int countKeplerTickets;

    public static bool[] puzzlesCleared = { false, false, false, false };

    public void ResetData()
    {
        currentlyInMenu = false;
        currentlyInPuzzle = false;
        itemsFound = new bool[] { true, false, false, false };
        countKeplerTickets = 0;
        puzzlesCleared = new bool[] { false, false, false, false };

}
}
