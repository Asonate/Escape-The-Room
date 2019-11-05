using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public int x;
    public int y;
    public bool canJumpTo;
    public bool HasVisited;

    private void OnMouseDown()
    {
        PuzzleThree.JumpField(x, y);
    }
}
