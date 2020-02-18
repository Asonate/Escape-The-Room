using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class DisplayMessageObject : InteractionObject
{
	[SerializeField] FirstPersonController player;
	[SerializeField] Canvas canvas;
	[SerializeField] Image image;
	[SerializeField] Text[] texts;
    
	public virtual void Start()
	{
		canvas.gameObject.SetActive(false);
		image.gameObject.SetActive(false);
		foreach (Text t in texts) t.gameObject.SetActive(false);
	}

	public override Color GetColor()
	{
		return Color.grey;
	}

	public override void Execute()
	{
        if (!(PlayerData.currentlyInMenu || PlayerData.currentlyInPuzzle))
        {
            StartCoroutine(ObjectAction());
		}
	}

	public virtual IEnumerator ObjectAction()
	{
		PlayerData.currentlyInMenu = true;
		yield return DisplayMessage(texts);
		PlayerData.currentlyInMenu = false;
	}

	public IEnumerator DisplayMessage(Text[] displayText)
	{
		canvas.gameObject.SetActive(true);
		image.gameObject.SetActive(true);

        player.mouseLookEnabled = false;
		
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		Time.timeScale = 0;

		yield return new WaitForSecondsRealtime(.025f);

		foreach (Text t in displayText)
		{
			t.gameObject.SetActive(true);

			yield return WaitForPlayerInput();

			t.gameObject.SetActive(false);
		}

        player.mouseLookEnabled = true;
		
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = false;
		Time.timeScale = 1;

		image.gameObject.SetActive(false);
		canvas.gameObject.SetActive(false);
	}

	public IEnumerator WaitForPlayerInput()
	{
		bool done = false;
		while (!done)
		{
			if (Input.GetButtonDown("Fire1"))
			{
				done = true;
			}
			yield return null;
		}
	}
}
