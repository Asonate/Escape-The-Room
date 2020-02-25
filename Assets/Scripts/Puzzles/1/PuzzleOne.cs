using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PuzzleOne : MonoBehaviour
{
    public static int maxCapacity = 10;
    static List<Bucket> buckets;

    [SerializeField] int puzzleId;
    [SerializeField] Canvas puzzle;

    [SerializeField] FirstPersonController player;
    [SerializeField] Canvas canvas;
    [SerializeField] Image image;
    [SerializeField] Text[] texts;

    public static bool firstSelected;
    public static Bucket first;

    // Start is called before the first frame update
    private void Start()
    {
        canvas.gameObject.SetActive(false);
        image.gameObject.SetActive(false);
        foreach (Text t in texts) t.gameObject.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        buckets = FindObjectsOfType<Bucket>().ToList();
        if (buckets != null)
        {
            foreach (Bucket b in buckets)
            {
                if (b.capacity == maxCapacity)
                {
                    b.current = maxCapacity;
                    break;
                }
            }
        }
        foreach (Bucket b in buckets) b.UpdateLabel();
    }

    public void ResetPuzzle()
    {
        foreach (Bucket b in buckets)
        {
            if (b.capacity == maxCapacity)
            {
                b.current = maxCapacity;
            }
            else
            {
                b.current = 0;
            }
        }
        foreach (Bucket b in buckets) b.UpdateLabel();
    }

    public bool CheckAnswer()
    {
        int count = 0;
        foreach (Bucket b in buckets)
        {
            if (b.current == maxCapacity / 2) count++;
        }
        return count == 2;
    }

    public void ClearPuzzle()
    {
        if (!PlayerData.currentlyInMenu)
        {
            StartCoroutine(DisplayMessage());
        }
    }

    public IEnumerator DisplayMessage()
    {
        PlayerData.currentlyInMenu = true;

        canvas.gameObject.SetActive(true);
        image.gameObject.SetActive(true);

        foreach (Text t in texts)
        {
            t.gameObject.SetActive(true);

            yield return WaitForPlayerInput();

            t.gameObject.SetActive(false);
        }

        player.mouseLookEnabled = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
        Time.timeScale = 1;

        canvas.gameObject.SetActive(false);
        image.gameObject.SetActive(false);

        PlayerData.currentlyInMenu = false;

        PlayerData.countKeplerTickets++;
        PlayerData.countPuzzlesCleared++;
        PlayerData.puzzlesCleared[puzzleId] = true;
        PlayerData.currentlyInPuzzle = false;
        puzzle.gameObject.SetActive(false);
    }

    public IEnumerator WaitForPlayerInput()
    {
        bool done = false;
        while (!done)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
            {
                done = true;
            }
            yield return null;
        }
    }
}
