using UnityEngine;
using UnityEngine.UI;

public class PuzzleFive : MonoBehaviour
{
    [SerializeField] FieldUnit field;
    [SerializeField] Transform parent;

    public Button buttonAssign;
    public static Button button;

    static FieldUnit[] fields = new FieldUnit[5];
    public static FieldUnit selectedField;
    public static bool fieldSelected;

    // Start is called before the first frame update
    void Start()
    {
        PlayerData.gamestate = 5;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        button = buttonAssign;
        for (int i = 0; i < 5; i++)
        {
            fields[i] = Instantiate(field, new Vector3(-2.2f + (i * 1.1f), 0, 0), Quaternion.identity, parent);
            fields[i].name = "[" + i + "]";
            fields[i].x = i;
        }

        SetupPlayArea();
        ColorPlayArea();

        Destroy(field.gameObject);
    }

    private static void SetupPlayArea()
    {

    }

    private static void ColorPlayArea()
    {
        foreach (FieldUnit f in fields)
        {
            f.GetComponent<Image>().color = Color.white;
            if (f.fieldState == FieldUnit.state.empty) f.GetComponent<Image>().color = Color.white;
            if (f.fieldState == FieldUnit.state.active) f.GetComponent<Image>().color = Color.blue;
            if (f.fieldState == FieldUnit.state.inactive) f.GetComponent<Image>().color = Color.gray;
            if (f.canJumpTo) f.GetComponent<Image>().color = Color.green;
        }
        if (selectedField) selectedField.GetComponent<Image>().color = Color.red;
    }

    public static void ShowOptions(int x)
    {
        fieldSelected = true;
        selectedField = fields[x];

        // TODO mark empty fields next to selection

        ColorPlayArea();
    }

    public static void FreeSelection()
    {
        selectedField = null;
        fieldSelected = false;

        foreach (FieldUnit f in fields)
        {
            f.canJumpTo = false;
        }

        ColorPlayArea();
    }

    public static void JumpField(int x)
    {
        fields[x].fieldState = selectedField.fieldState;
        selectedField.fieldState = FieldUnit.state.empty;

        // TODO swap state of fields inbetween
        
        FreeSelection();
        if (CheckAnswer()) ClearPuzzle();
    }

    public static void ResetField()
    {
        selectedField = null;
        fieldSelected = false;
        SetupPlayArea();
        ColorPlayArea();
    }

    public static bool CheckAnswer()
    {
        foreach (FieldUnit f in fields)
        {
            if (f.fieldState == FieldUnit.state.inactive) return false;
        }
        return true;
    }

    public static void ClearPuzzle()
    {
        button.onClick.Invoke();
    }
}