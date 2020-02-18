using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleTwo : MonoBehaviour
{
    [SerializeField] FieldBlock fieldBlock;
    [SerializeField] Transform parent;
    [SerializeField] Text textbase;

    static FieldBlock[,] field = new FieldBlock[5, 5];
    static Text text;
    static int placeableQueens = 5;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                field[i, j] = Instantiate(fieldBlock, new Vector3(-2.2f + (i * 1.1f), -4f + (j * 1.1f), 0), Quaternion.identity, parent);
                field[i, j].name = "[" + i + "," + j + "]";
                field[i, j].x = i;
                field[i, j].y = j;
            }
        }

        Destroy(fieldBlock.gameObject);

        text = Instantiate(textbase, textbase.transform.position, Quaternion.identity, parent);
        text.name = "QueenCount";

        Destroy(textbase.gameObject);
    }

    public static void PlaceQueen(int x, int y)
    {
        if (field[x, y].queenPlaced)
        {
            field[x, y].GetComponent<Image>().color = Color.white;
            field[x, y].queenPlaced = false;
            placeableQueens++;
            UpdateLabel();
        }
        else if (placeableQueens > 0)
        {
            field[x, y].GetComponent<Image>().color = Color.red;
            field[x, y].queenPlaced = true;
            placeableQueens--;
            UpdateLabel();
        }
    }

    public static void UpdateLabel()
    {
        text.text = "Placed \nQueens \n" + (5 - placeableQueens) + " / 5";
    }

    public static void ResetField()
    {
        foreach (FieldBlock f in field)
        {
            f.GetComponent<Image>().color = Color.white;
            f.queenPlaced = false;
            f.inCheck = false;
        }
        placeableQueens = 5;
        UpdateLabel();
    }

    public static bool CheckAnswer()
    {
        foreach (FieldBlock f in field)
        {
            f.GetComponent<Image>().color = Color.white;
            f.inCheck = false;
        }

        foreach (FieldBlock f in field) if (f.queenPlaced)
            {
                f.GetComponent<Image>().color = Color.red;

                for (int i = 0; i < 5; i++)
                {
                    if (i != f.y)
                    {
                        field[f.x, i].inCheck = true;
                        field[f.x, i].GetComponent<Image>().color = Color.blue;
                    }

                    if (i != f.x)
                    {
                        field[i, f.y].inCheck = true;
                        field[i, f.y].GetComponent<Image>().color = Color.blue;
                    }
                }
                for (int i = -4; i < 5; i++) if (i != 0)
                {
                    if (f.x + i >= 0 && f.x + i < 5 && f.y + i >= 0 && f.y + i < 5)
                    {
                        field[f.x + i, f.y + i].inCheck = true;
                        field[f.x + i, f.y + i].GetComponent<Image>().color = Color.blue;
                    }

                    if (f.x + i >= 0 && f.x + i < 5 && f.y - i >= 0 && f.y - i < 5)
                    {
                        field[f.x + i, f.y - i].inCheck = true;
                        field[f.x + i, f.y - i].GetComponent<Image>().color = Color.blue;
                    }
                }
            }

        foreach (FieldBlock f in field) if (f.queenPlaced && f.inCheck)
            {
                f.GetComponent<Image>().color = Color.black;
            }

        foreach (FieldBlock f in field)
        {
            if ((!f.inCheck && !f.queenPlaced) || (f.inCheck && f.queenPlaced))
            {
                return false;
            }
        }
        return true;
    }
}