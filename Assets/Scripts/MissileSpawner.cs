using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
	public GameObject MissilePrefab;
	private Vector2 spawnXBounds = new Vector2(-7.5f, 7.5f);
	private Vector2 spawnYBounds = new Vector2(-4f, 6f);
	private float spawnTimeMax = 2.9f;
	private float spawnTimer = 0f;

	private float peaceTime = 7f;
	private float waveTime = 15f;

	private string state = "peace";
	private float stateTimer = 0f;

	private int wave = 0;

	private bool firstPeace = false;

	private void Update()
	{
		// Update state

		// Make sure all missiles are destroyed to start counting peace
		if (state == "wave" || (state == "peace" && GameManager.Instance.MissilesHolder.childCount == 0))
		{
			stateTimer += Time.deltaTime;

			if (firstPeace)
			{
				// Say wave is over
				firstPeace = false;
				Radar.DeclarePeace();
				PeaceText.ShowPeaceText(peaceTime);
			}
		}

		if (stateTimer >= (state == "peace" ? peaceTime : waveTime))
		{
			stateTimer = 0f;
			if (state == "peace")
			{
				state = "wave";
				wave++;
				spawnTimer = spawnTimeMax - 1f; // Start the wave in a second
				Radar.DeclareWave();
				WaveText.ShowWaveText(wave);
			}
			else
			{
				state = "peace";
				firstPeace = true;
			}
		}

		if (state == "wave")
		{
			spawnTimer += Time.deltaTime;
			if (spawnTimer >= spawnTimeMax)
			{
				spawnTimer = 0f;
				Instantiate(MissilePrefab, GetRandomPosOut(), Quaternion.identity, GameManager.Instance.MissilesHolder);
			}
		}
		else if (state == "peace")
		{
			// Do nothing... let the player rebuild
		}
	}

	private Vector2 GetRandomPosOut()
	{
		Vector2 pos;
		int r0 = Random.Range(0, 2);
		int r1 = Random.Range(0, 2);
		if (r0 == 0)
		{
			pos.x = Random.Range(spawnXBounds.x, spawnXBounds.y);
			if (r1 == 0)
				pos.y = spawnYBounds.x;
			else
				pos.y = spawnYBounds.y;
		}
		else
		{
			if (r1 == 0)
				pos.x = spawnXBounds.x;
			else
				pos.x = spawnXBounds.y;

			pos.y = Random.Range(spawnYBounds.x, spawnYBounds.y);
		}

		return pos;
	}
}
