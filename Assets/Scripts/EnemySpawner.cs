using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject MissilePrefab;
	public GameObject ShipPrefab;

	private Vector2 spawnXBounds = new Vector2(-7.5f, 7.5f);
	private Vector2 spawnYBounds = new Vector2(-4f, 6f);
	private float spawnTimeMax = 2.9f;
	private float spawnTimer = 0f;

	private float peaceTimeMax = 7f;

	private string state = "peace";
	private float peaceTimer = 0f;

	private int wave = 0;
	private int enemiesWaveCounter = 0;
	private int enemiesPerWave = 5;

	private bool firstPeace = false;

	private void Update()
	{
		// Update state

		// Make sure all enemies are destroyed to start counting peace
		if (state == "peace" && GetEnemiesLeft() == 0)
		{
			peaceTimer += Time.deltaTime;

			if (firstPeace)
			{
				// Say wave is over
				firstPeace = false;
				Radar.DeclarePeace();
				PeaceText.ShowPeaceText(peaceTimeMax);
			}
		}

		if (peaceTimer >= peaceTimeMax)
		{
			peaceTimer = 0f;
			enemiesWaveCounter = 0;
			state = "wave";
			wave++;
			enemiesPerWave++;
			spawnTimer = spawnTimeMax - 1f; // Start the wave in a second
			Radar.DeclareWave();
			WaveText.ShowWaveText(wave);
		}

		if (state == "wave")
		{
			spawnTimer += Time.deltaTime;
			if (spawnTimer >= spawnTimeMax && enemiesWaveCounter < enemiesPerWave)
			{
				spawnTimer = 0f;
				Instantiate(MissilePrefab, GetRandomPosOut(), Quaternion.identity, GameManager.Instance.EnemiesHolder.GetChild(0));

				enemiesWaveCounter++;
				if (enemiesWaveCounter == enemiesPerWave) // Go to peace if all enemies have been spawned
				{
					state = "peace";
					firstPeace = true;
				}
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

	private int GetEnemiesLeft()
	{
		int enemies = 0;
		Transform enemiesHolder = GameManager.Instance.EnemiesHolder;
		for (int i = 0; i < enemiesHolder.childCount; i++)
		{
			enemies += enemiesHolder.GetChild(i).childCount;
		}

		return enemies;
	}
}
