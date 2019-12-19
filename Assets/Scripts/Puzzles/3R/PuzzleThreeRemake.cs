using UnityEngine;
using UnityEngine.UI;

public class PuzzleThreeRemake : MonoBehaviour
{
    [SerializeField] PlayField field;
    [SerializeField] Transform parent;

    public Button buttonAssign;
    public static Button button;

    static PlayField[,] fields = new PlayField[7, 7];
    public static PlayField selectedField;
    public static bool fieldSelected;

    // Start is called before the first frame update
    void Start()
    {
        PlayerData.gamestate = 3;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        button = buttonAssign;
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                fields[i, j] = Instantiate(field, new Vector3(-2.7f + (i * .9f), -4.8f + (j * .9f), 0), Quaternion.identity, parent);
                fields[i, j].name = "[" + i + "," + j + "]";
                fields[i, j].x = i;
                fields[i, j].y = j;
            }
        }

        SetupPlayArea();
        SetupMarbles();
        ColorPlayArea();

        Destroy(field.gameObject);
    }

    private static void SetupPlayArea()
    {
        foreach (PlayField f in fields)
        {
            f.isPlayArea = true;
            f.canJumpTo = false;
            f.hasMarble = false;
        }
        fields[0, 0].isPlayArea = false;
        fields[1, 0].isPlayArea = false;
        fields[0, 1].isPlayArea = false;
        fields[1, 1].isPlayArea = false;
        fields[6, 6].isPlayArea = false;
        fields[5, 6].isPlayArea = false;
        fields[6, 5].isPlayArea = false;
        fields[5, 5].isPlayArea = false;
        fields[0, 6].isPlayArea = false;
        fields[0, 5].isPlayArea = false;
        fields[6, 0].isPlayArea = false;
        fields[5, 0].isPlayArea = false;
        fields[1, 6].isPlayArea = false;
        fields[1, 5].isPlayArea = false;
        fields[6, 1].isPlayArea = false;
        fields[5, 1].isPlayArea = false;
    }

    private static void SetupMarbles()
    {
        fields[3, 5].hasMarble = true;
        fields[2, 4].hasMarble = true;
        fields[3, 4].hasMarble = true;
        fields[4, 4].hasMarble = true;
        fields[3, 3].hasMarble = true;
        fields[3, 2].hasMarble = true;
    }

    private static void ColorPlayArea()
    {
        foreach (PlayField f in fields)
        {
            f.GetComponent<Image>().color = Color.white;
            if (!f.isPlayArea) f.GetComponent<Image>().color = Color.gray;
            if (!f.isPlayArea) f.GetComponent<Image>().gameObject.SetActive(false);
            if (f.hasMarble) f.GetComponent<Image>().color = Color.blue;
            if (f.canJumpTo) f.GetComponent<Image>().color = Color.green;
        }
        if (selectedField) selectedField.GetComponent<Image>().color = Color.red;
    }

    public static void ShowOptions(int x, int y)
    {
        fieldSelected = true;
        selectedField = fields[x, y];

        if (x + 2 <= 6)
        {
            if (fields[x + 1, y].hasMarble && !fields[x + 2, y].hasMarble && fields[x + 2, y].isPlayArea)
            {
                fields[x + 2, y].canJumpTo = true;
            }
        }
        if (x - 2 >= 0)
        {
            if (fields[x - 1, y].hasMarble && !fields[x - 2, y].hasMarble && fields[x - 2, y].isPlayArea)
            {
                fields[x - 2, y].canJumpTo = true;
            }
        }
        if (y + 2 <= 6)
        {
            if (fields[x, y + 1].hasMarble && !fields[x, y + 2].hasMarble && fields[x, y + 2].isPlayArea)
            {
                fields[x, y + 2].canJumpTo = true;
            }
        }
        if (y - 2 >= 0)
        {
            if (fields[x, y - 1].hasMarble && !fields[x, y - 2].hasMarble && fields[x, y - 2].isPlayArea)
            {
                fields[x, y - 2].canJumpTo = true;
            }
        }
        ColorPlayArea();
    }

    public static void FreeSelection()
    {
        selectedField = null;
        fieldSelected = false;
        foreach (PlayField f in fields)
        {
            f.canJumpTo = false;
        }
        ColorPlayArea();
    }

    public static void JumpField(int x, int y)
    {
        if (fields[x, y].canJumpTo)
        {
            selectedField.hasMarble = false;
            fields[x + (selectedField.x - x) / 2, y + (selectedField.y - y) / 2].hasMarble = false;
            fields[x, y].hasMarble = true;
        }
        FreeSelection();
        if (CheckAnswer()) ClearPuzzle();
    }

    public static void ResetField()
    {
        selectedField = null;
        fieldSelected = false;
        SetupPlayArea();
        SetupMarbles();
        ColorPlayArea();
    }

    public static bool CheckAnswer()
    {
        int count = 0;
        foreach (PlayField f in fields)
        {
            if (f.hasMarble) count++;
        }
        return count == 1;
    }

    public static void ClearPuzzle()
    {
        button.onClick.Invoke();
    }
}