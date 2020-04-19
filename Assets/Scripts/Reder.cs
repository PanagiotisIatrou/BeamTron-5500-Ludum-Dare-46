using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Reder : MonoBehaviour
{
	// Singleton
	private static Reder _instance;
	public static Reder Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = GameObject.FindObjectOfType<Reder>();
			}

			return _instance;
		}
	}

	public Image RedImage;

	private bool working;
	private float totalTime = 1f;
	private float greenPercentage = 70f / 255f;
	private IEnumerator redCor;

	public static void MakeRed(string mode = "")
	{
		if (Instance.working)
			Instance.StopReder();
		Instance.redCor = Instance.IEMakeRed(mode);
		Instance.StartCoroutine(Instance.redCor);
	}

	private IEnumerator IEMakeRed(string mode = "")
	{
		working = true;
		Color col = RedImage.color;

		if (mode == "red")
			col = new Color(1f, 0f, 0f, greenPercentage * 2f);
		else if (mode == "dead")
			col = new Color(1f, 0f, 0f, 1f);
		else if (mode == "green")
			col = new Color(0f, 1f, 0f, greenPercentage);

		RedImage.color = col;

		while (RedImage.color.a > 0f)
		{
			col = RedImage.color;
			col.a -= Time.deltaTime / totalTime;
			RedImage.color = col;
			yield return null;
		}
		col.a = 0f;
		if (mode == "green")
			col = new Color(1f, 0f, 0f, 0f);
		RedImage.color = col;
		working = false;
	}

	private void StopReder()
	{
		StopCoroutine(redCor);
		Color col = RedImage.color;
		col.a = 0f;
		RedImage.color = col;
		working = false;
	}

}
