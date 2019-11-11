using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionObject : MessageObject
{
    [SerializeField] string sceneName;

    int objectIndex;

    private void Awake()
    {
        objectIndex = PlayerData.objectIndex++;
    }

    private void OnEnable()
    {
        if (PlayerData.clickedObjects.Contains(objectIndex))
        {
            Start();
            gameObject.SetActive(false);
            Destroy(this);
        }
    }

    public override Color GetColor()
    {
        return Color.green;
    }

    public override void Highlight()
    {
        //Play an animation
    }

    public override void Execute()
    {
        if (!PlayerData.currentlyInMenu)
        {
            StartCoroutine(ObjectAction());
        }
    }

    public override IEnumerator ObjectAction()
    {
        PlayerData.currentlyInMenu = true;
        yield return StartCoroutine(DisplayMessage());
        PlayerData.currentlyInMenu = false;

        PlayerData.clickedObjects.Add(objectIndex);

        SceneManager.LoadScene(sceneName);

        gameObject.SetActive(false);
    }
}