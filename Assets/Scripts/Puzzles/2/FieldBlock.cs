using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldBlock : MonoBehaviour
{
    public int x;
    public int y;
    public bool queenPlaced;
    public bool inCheck;

    private void OnMouseDown()
    {
        if (!PlayerData.currentlyInMenu)
        {
            PuzzleTwo.PlaceQueen(x, y);
        }
    }
}
