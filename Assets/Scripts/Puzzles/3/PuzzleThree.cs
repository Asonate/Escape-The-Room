using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleThree : MonoBehaviour
{
    [SerializeField] Field field;
    [SerializeField] Transform parent;

    static Field[,] fields = new Field[3,4];
    static Field ActiveField;

    // Start is called before the first frame update
    void Start()
    {
        PlayerData.gamestate = 3;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                fields[i, j] = Instantiate(field, new Vector3(-1.1f + (i * 1.1f), -3f + (j * 1.1f), 0), Quaternion.identity, parent);
                fields[i, j].name = "[" + i + "," + j + "]";
                fields[i, j].x = i;
                fields[i, j].y = j;
            }
        }

        ActiveField = fields[0, 3];
        ActiveField.HasVisited = true;

        ShowOptions();

        Destroy(field.gameObject);
    }

    public static void JumpField(int x, int y)
    {
        if (fields[x, y].canJumpTo)
        {
            fields[x, y].GetComponent<Image>().color = Color.white;

            ActiveField = fields[x, y];
            ActiveField.HasVisited = true;
            ShowOptions();
        }
    }

    public static void ShowOptions()
    {
        int x = ActiveField.x;
        int y = ActiveField.y;

        foreach (Field f in fields)
        {
            f.canJumpTo = false;
        }

        if (x - 1 < 3 && x - 1 >= 0 && y - 2 < 4 && y - 2 >= 0) fields[x - 1, y - 2].canJumpTo = true;
        if (x - 2 < 3 && x - 2 >= 0 && y - 1 < 4 && y - 1 >= 0) fields[x - 2, y - 1].canJumpTo = true;
        if (x + 1 < 3 && x + 1 >= 0 && y + 2 < 4 && y + 2 >= 0) fields[x + 1, y + 2].canJumpTo = true;
        if (x + 2 < 3 && x + 2 >= 0 && y + 1 < 4 && y + 1 >= 0) fields[x + 2, y + 1].canJumpTo = true;
        if (x + 1 < 3 && x + 1 >= 0 && y - 2 < 4 && y - 2 >= 0) fields[x + 1, y - 2].canJumpTo = true;
        if (x + 2 < 3 && x + 2 >= 0 && y - 1 < 4 && y - 1 >= 0) fields[x + 2, y - 1].canJumpTo = true;
        if (x - 1 < 3 && x - 1 >= 0 && y + 2 < 4 && y + 2 >= 0) fields[x - 1, y + 2].canJumpTo = true;
        if (x - 2 < 3 && x - 2 >= 0 && y + 1 < 4 && y + 1 >= 0) fields[x - 2, y + 1].canJumpTo = true;

        foreach (Field f in fields) if (f.canJumpTo && f.HasVisited)
            {
                f.canJumpTo = false;
            }

        ColorField();
    }

    private static void ColorField()
    {
        foreach (Field f in fields)
        {
            f.GetComponent<Image>().color = Color.white;
            if (f.HasVisited) f.GetComponent<Image>().color = Color.blue;
            if (f.canJumpTo) f.GetComponent<Image>().color = Color.green;
            ActiveField.GetComponent<Image>().color = Color.red;
        }
    }

    public static void ResetField()
    {
        foreach (Field f in fields)
        {
            f.GetComponent<Image>().color = Color.white;
            f.HasVisited = false;
        }

        ActiveField = fields[0, 3];
        fields[0, 3].HasVisited = true;

        ShowOptions();
    }

    public static bool CheckAnswer()
    {
        foreach (Field f in fields)
        {
            if (!f.HasVisited) return false;
        }
        return true;
    }
}