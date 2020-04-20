using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Console : MonoBehaviour
{
	public TextMeshProUGUI ConsoleText;
	public GameObject CursorObj;
	public AudioClip audioClip;
	private Image cursorImage;
	private int maxCharactersPerLine = 18;
	private string text = "";
	private string preText = "C:\\";
	private bool cursorOn = true;
	private float cursorBlinkTimeMax = 0.3f;
	private float cursorBlinkTimer = 0f;

	private void Start()
	{
		text = preText;
		cursorImage = CursorObj.GetComponent<Image>();
	}

	private void Update()
	{
		foreach (char c in Input.inputString)
		{
			Vector3 pos = transform.position;
			pos.z = -10f;
			AudioSource.PlayClipAtPoint(audioClip, pos, 0.35f);
			if (c == '\b')
			{
				if (text.Length > preText.Length)
					text = text.Substring(0, text.Length - 1);
			}
			else if (c == '\n' || c == '\r')
			{
				SendCommand(text);
				text = preText;
			}
			else if (text.Length < maxCharactersPerLine)
			{
				text += c;
			}
		}

		if (text.Length > maxCharactersPerLine)
		{
			int diff = text.Length - maxCharactersPerLine;
			text = text.Substring(diff, text.Length - diff);
		}

		ConsoleText.SetText(text);

		if (ConsoleText.textInfo.characterCount > 0)
		{
			Vector3 bottomRight = ConsoleText.textInfo.characterInfo[ConsoleText.textInfo.characterCount - 1].bottomLeft;
			bottomRight.y = -9.1f;
			CursorObj.GetComponent<RectTransform>().localPosition = bottomRight += new Vector3(35f, 0f, 0f);
		}
		else
		{
			CursorObj.GetComponent<RectTransform>().localPosition = new Vector3(-80f, -11.1f, 0f);
		}

		cursorBlinkTimer += Time.deltaTime;
		if (cursorBlinkTimer >= cursorBlinkTimeMax)
		{
			cursorBlinkTimer = 0f;
			cursorOn = !cursorOn;
			cursorImage.enabled = cursorOn;
		}
	}

	private void SendCommand(string command)
	{
		command = command.Substring(preText.Length, command.Length - preText.Length);
		command = command.ToLower();
		if (command == "heal")
		{
			Health.Heal(10);
			Reder.MakeRed("green");
		}
		else if (command == "destroy")
		{
			MissilesDestroyer.DestroyClosestMissile();
		}
		else if (command == "destroy big")
		{
			MissilesDestroyer.DestroyClosestShip();
		}
		else if (command == "recycle")
		{
			Oxygen.IncreaseOxygenByPercent(20);
		}
		else if (command == "self destroy")
		{
			GameManager.Die();
		}
	}
}
