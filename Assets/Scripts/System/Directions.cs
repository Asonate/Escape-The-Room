using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Directions : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] Text textBase;
    static Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = textBase;
    }

    public static void ChangeText(string newText)
    {
        text.text = newText;
    }

    private void Update()
    {
        if(PlayerData.currentlyInMenu)
        {
            canvasGroup.alpha = 0f;
        } else
        {
            canvasGroup.alpha = 1f;
        }
    }
}
