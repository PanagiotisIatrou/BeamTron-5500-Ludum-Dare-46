using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PeaceText : MonoBehaviour
{
	// Singleton
	private static PeaceText _instance;
	public static PeaceText Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = GameObject.FindObjectOfType<PeaceText>();
			}

			return _instance;
		}

	}

	public TextMeshProUGUI peaceText;

	public static void ShowPeaceText(float peaceTime)
	{
		Instance.StartCoroutine(Instance.IEShowPeaceText(peaceTime));
	}

	public IEnumerator IEShowPeaceText(float peaceTime)
	{
		peaceTime -= 1.5f;

		Instance.peaceText.gameObject.SetActive(true);
		Instance.peaceText.SetText("GOOD JOB!\nPEACE ENDS IN\n" + (Mathf.FloorToInt(peaceTime) + 1));

		while (Instance.peaceText.color.a < 1f)
		{
			Color color = Instance.peaceText.color;
			Instance.peaceText.color = new Color(color.r, color.g, color.b, color.a + Time.deltaTime * 2f);
			yield return null;
		}

		float timer = peaceTime;
		while (timer > 0)
		{
			timer -= Time.deltaTime;

			if (timer <= 0) // Prevent showing 0
				break;

			Instance.peaceText.SetText("GOOD JOB!\nPEACE ENDS IN\n" + (Mathf.FloorToInt(timer) + 1));
			yield return null;
		}

		while (Instance.peaceText.color.a > 0f)
		{
			Color color = Instance.peaceText.color;
			Instance.peaceText.color = new Color(color.r, color.g, color.b, color.a - Time.deltaTime * 2f);
			yield return null;
		}

		Instance.peaceText.gameObject.SetActive(false);
	}
}
