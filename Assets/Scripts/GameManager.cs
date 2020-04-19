using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	// Singleton
	private static GameManager _instance;
	public static GameManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = GameObject.FindObjectOfType<GameManager>();
			}

			return _instance;
		}
	}

	public Transform MissilesHolder;
	public Transform ExplosionPrefab;

	public static bool died = false;

	private void Update()
	{
		if (!died && (Health.GetHealth() == 0 || Oxygen.GetOxygen() == 0f))
		{
			Die();
		}
	}

	public static void Die()
	{
		died = true;
		Shaker.SetShakeLengthSpeed(1f, 55f);
		Shaker.Shake(0.12f);
		Reder.MakeRed("dead");
		Time.timeScale = 0.5f;
		BlackFader.GoToScene("MainMenu", UnityEngine.SceneManagement.LoadSceneMode.Single, 1f, Instance.Ressurect, null);
	}

	private void Ressurect()
	{
		died = false;
		Time.timeScale = 1f;
		Shaker.SetShakeLengthSpeed(0.2f, 40f);
	}
}
