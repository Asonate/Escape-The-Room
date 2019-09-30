using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class ClickableObject : MonoBehaviour
{
    public abstract Color GetColor();

    public abstract void Highlight();

    public abstract void Execute();
}
