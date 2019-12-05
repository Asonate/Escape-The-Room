using UnityEngine;

public class FieldUnit : MonoBehaviour
{
    public int x;
    public int y;
    public enum state {
        active,
        inactive,
        empty
    }
    public bool canJumpTo;
    public state fieldState = state.empty;

    private void OnMouseDown()
    {
        if (!PlayerData.currentlyInMenu && this.fieldState != state.empty)
        {
            if (!PuzzleFive.fieldSelected)
            {
                PuzzleFive.ShowOptions(x);
            }
            else if (this == PuzzleFive.selectedField)
            {
                PuzzleFive.FreeSelection();
            }
        }
        else if (!PlayerData.currentlyInMenu && this.canJumpTo)
        {
            PuzzleFive.JumpField(x);

        }
    }
}
