using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerData : MonoBehaviour
{
    [SerializeField] FirstPersonController player;
    [SerializeField] Canvas reticle;

    public static bool clueShown;
    public static bool allowMenu = true;
    public static bool currentlyInMenu;
    public static bool currentlyInPuzzle;
    private static bool displayReticle = true;

    public static bool[] itemsFound = { true, false, false, false };

    public static int countKeplerTickets;

    public static bool[] puzzlesCleared = { false, false, false, false, false };

    private void Start()
    {
        ResetData();
    }

    public void ResetData()
    {
        clueShown = false;
        allowMenu = true;
        currentlyInMenu = false;
        currentlyInPuzzle = false;
        displayReticle = true;
        itemsFound = new bool[] { true, false, false, false };
        countKeplerTickets = 0;
        puzzlesCleared = new bool[] { false, false, false, false, false };

        player.mouseLookEnabled = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    private void Update()
    {
        if((currentlyInMenu || currentlyInPuzzle) && displayReticle)
        {
            displayReticle = false;
            reticle.gameObject.SetActive(false);
        } else if(!(currentlyInMenu || currentlyInPuzzle) && !displayReticle)
        {
            displayReticle = true;
            reticle.gameObject.SetActive(true);
        }
    }
}
