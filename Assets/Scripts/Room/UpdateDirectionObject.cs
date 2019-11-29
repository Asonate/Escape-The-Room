using UnityEngine;
using System.Collections;

public class UpdateDirectionObject : MonoBehaviour
{
    [SerializeField] string newDirection;

    ClickableObject mainObject;

    private void Start()
    {
        mainObject = GetComponent<ClickableObject>();
    }

    public Color GetColor()
    {
        return mainObject.GetColor();
    }

    public void Highlight()
    {
        mainObject.Highlight();
    }

    public void Execute()
    {
        Directions.ChangeText(newDirection);
        mainObject.Execute();
    }
}
