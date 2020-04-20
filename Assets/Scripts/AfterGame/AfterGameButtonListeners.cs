using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AfterGameButtonListeners : MonoBehaviour
{
	public TextMeshProUGUI yearsText;
	public AudioClip loseClip;
	public static int year;

	private void Awake()
	{
		yearsText.SetText("YOU MADE IT TO YEAR " + year + "!");
		AudioSource.PlayClipAtPoint(loseClip, Camera.main.transform.position);
	}

	public void OnMainMenuButtonListener()
	{
		BlackFader.GoToScene("MainMenu", UnityEngine.SceneManagement.LoadSceneMode.Single, 0.8f);
	}

	public void OnRestartButtonListener()
	{
		BlackFader.GoToScene("Game", UnityEngine.SceneManagement.LoadSceneMode.Single, 0.8f);
	}
}
