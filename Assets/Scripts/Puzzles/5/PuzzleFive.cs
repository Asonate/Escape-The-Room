using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PuzzleFive : MonoBehaviour
{
    [SerializeField] int puzzleId;
    [SerializeField] Canvas puzzle;

    [SerializeField] FirstPersonController player;
    [SerializeField] Canvas canvas;
    [SerializeField] Image image;
    [SerializeField] Text[] successText;
    [SerializeField] Text[] failureText;

    [SerializeField] Text input;

    public int[] code = new int[4];
    int pos;
    int[] solution = { 1, 9, 6, 6 };

    // Start is called before the first frame update
    void Start()
    {
        canvas.gameObject.SetActive(false);
        image.gameObject.SetActive(false);
        foreach (Text t in successText) t.gameObject.SetActive(false);
        foreach (Text t in failureText) t.gameObject.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        DisplayInput();
    }

    public void Add(int i)
    {
        if (pos <= 3 && !PlayerData.currentlyInMenu)
        {
            code[pos] = i;
            pos++;
            DisplayInput();
        }

        if (pos >= 4)
        {
            if (CheckAnswer())
            {
                ClearPuzzle();
            } else
            {
                StartCoroutine(DisplayError());
                ResetField();
            }
        }
    }

    public void DisplayInput()
    {
        string displayText = "Eingabe: ";
        if (code[0] == 0)
        {
            displayText += "_ ";
        }
        else
        {
            displayText += code[0].ToString() + " ";
        }
        if (code[1] == 0)
        {
            displayText += "_ ";
        }
        else
        {
            displayText += code[1].ToString() + " ";
        }
        if (code[2] == 0)
        {
            displayText += "_ ";
        }
        else
        {
            displayText += code[2].ToString() + " ";
        }
        if (code[3] == 0)
        {
            displayText += "_ ";
        }
        else
        {
            displayText += code[3].ToString() + " ";
        }
        input.text = displayText;
    }

    public void ResetField()
    {
        code = new int[4];
        pos = 0;
        DisplayInput();
    }

    public IEnumerator DisplayError()
    {
        PlayerData.currentlyInMenu = true;

        canvas.gameObject.SetActive(true);
        image.gameObject.SetActive(true);

        foreach (Text t in failureText)
        {
            t.gameObject.SetActive(true);

            yield return WaitForPlayerInput();

            t.gameObject.SetActive(false);
        }

        canvas.gameObject.SetActive(false);
        image.gameObject.SetActive(false);

        PlayerData.currentlyInMenu = false;
    }

    public bool CheckAnswer()
    {
        return code[0] == solution[0] && code[1] == solution[1] && code[2] == solution[2] && code[3] == solution[3];
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

        foreach (Text t in successText)
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
        PlayerData.puzzlesCleared[puzzleId] = true;
        PlayerData.currentlyInPuzzle = false;
        //loadend
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