using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveText : MonoBehaviour
{
	// Singleton
	private static WaveText _instance;
	public static WaveText Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = GameObject.FindObjectOfType<WaveText>();
			}

			return _instance;
		}

	}

	public TextMeshProUGUI waveText;

	public static void ShowWaveText(int wave)
    {
		Instance.StartCoroutine(Instance.IEShowWaveText(wave));
	}

	public IEnumerator IEShowWaveText(int wave)
	{
		Instance.waveText.gameObject.SetActive(true);
		Instance.waveText.SetText("WAVE: " + wave);

		while (Instance.waveText.color.a < 1f)
		{
			Color color = Instance.waveText.color;
			Instance.waveText.color = new Color(color.r, color.g, color.b, color.a + Time.deltaTime * 2f);
			yield return null;
		}

		yield return new WaitForSeconds(0.5f);

		while (Instance.waveText.color.a > 0f)
		{
			Color color = Instance.waveText.color;
			Instance.waveText.color = new Color(color.r, color.g, color.b, color.a - Time.deltaTime * 2f);
			yield return null;
		}

		Instance.waveText.gameObject.SetActive(false);
	}
}
