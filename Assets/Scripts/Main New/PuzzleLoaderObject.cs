using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleLoaderObject : DisplayMessageObject
{
	[SerializeField] int requiredItem; //0 for none
	[SerializeField] int puzzleID;
	[SerializeField] Canvas puzzle;

	[SerializeField] Canvas canvas;
	[SerializeField] Image image;
	[SerializeField] Text[] clearedTexts;
	[SerializeField] Text[] successTexts;
	[SerializeField] Text[] failureTexts;

	public override void Start()
	{
		canvas.gameObject.SetActive(false);
		image.gameObject.SetActive(false);
		foreach (Text t in clearedTexts) t.gameObject.SetActive(false);
		foreach (Text t in successTexts) t.gameObject.SetActive(false);
		foreach (Text t in failureTexts) t.gameObject.SetActive(false);
	}

	public override Color GetColor()
	{
		return Color.red;
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
        if (PlayerData.puzzlesCleared[puzzleID])
		{
			PlayerData.currentlyInMenu = true;
			yield return StartCoroutine(DisplayMessage(clearedTexts));
			PlayerData.currentlyInMenu = false;
		}
        else if (PlayerData.itemsFound[requiredItem])
		{
			PlayerData.currentlyInMenu = true;
			yield return StartCoroutine(DisplayMessage(successTexts));
			PlayerData.currentlyInMenu = false;

			puzzle.gameObject.SetActive(true);
		}
		else
		{
			PlayerData.currentlyInMenu = true;
			yield return StartCoroutine(DisplayMessage(failureTexts));
			PlayerData.currentlyInMenu = false;
		}
	}
}

