using UnityEngine;

public class PlayField : MonoBehaviour
{
    [SerializeField] PuzzleFour puzzle;

    public int x;
    public int y;
    public bool hasMarble;
    public bool canJumpTo;
    public bool isPlayArea;

    public void FieldAction()
    {
        if (!PlayerData.currentlyInMenu && this.isPlayArea)
        {
            if (!puzzle.fieldSelected && this.hasMarble)
            {
                puzzle.ShowOptions(x, y);
            } else if (this.canJumpTo && !this.hasMarble)
            {
                puzzle.JumpField(x, y);
            } else if (this == puzzle.selectedField)
            {
                puzzle.FreeSelection();
            }
        }
    }
}
