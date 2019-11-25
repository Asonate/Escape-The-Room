using UnityEngine;

public class PlayField : MonoBehaviour
{
    public int x;
    public int y;
    public bool hasMarble;
    public bool canJumpTo;
    public bool isPlayArea;

    private void OnMouseDown()
    {
        if (!PlayerData.currentlyInMenu && this.isPlayArea)
        {
            if (!PuzzleFour.fieldSelected && this.hasMarble)
            {
                PuzzleFour.ShowOptions(x, y);
            } else if (this.canJumpTo && !this.hasMarble)
            {
                PuzzleFour.JumpField(x, y);
            } else if (this == PuzzleFour.selectedField)
            {
                PuzzleFour.FreeSelection();
            }
        }
    }
}
