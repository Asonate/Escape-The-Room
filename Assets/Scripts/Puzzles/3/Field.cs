using UnityEngine;

public class Field : MonoBehaviour
{
    public int x;
    public int y;
    public bool canJumpTo;
    public bool HasVisited;

    private void OnMouseDown()
    {
        if (!PlayerData.currentlyInMenu)
        {
            PuzzleThree.JumpField(x, y);
        }
    }
}
