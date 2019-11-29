using UnityEngine;
using System.Collections;

public class DirectionUpdater : MonoBehaviour
{
    [SerializeField] string newDirection;

    public void Execute()
    {
        Directions.ChangeText(newDirection);
    }
}
