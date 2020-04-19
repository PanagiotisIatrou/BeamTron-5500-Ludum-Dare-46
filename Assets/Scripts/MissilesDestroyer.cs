using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilesDestroyer : MonoBehaviour
{
	public static void DestroyClosestMissile()
	{
		DestroyClosest(GameManager.Instance.EnemiesHolder.GetChild(0), "missile");
	}

	public static void DestroyClosestShip()
	{
		DestroyClosest(GameManager.Instance.EnemiesHolder.GetChild(1), "ship");
	}

	private static void DestroyClosest(Transform parent, string type)
    {
		if (parent.childCount == 0) // No enemies found, so nothing to do here
			return;

		// Find closest enemy...
		Transform closestEnemy = null;
		float minDist = -1f;
		for (int i = 0; i < parent.childCount; i++)
        {
			Transform missile = parent.GetChild(i);
			float dist = Vector2.Distance(Earth.Instance.transform.position, missile.position);
			if (i == 0 ||  dist < minDist)
			{
				minDist = dist;
				closestEnemy = missile;
			}
		}

		// ...and destroy it
		if (type == "missile")
			closestEnemy.GetComponent<Missile>().DestroyMissile();
		else if (type == "ship")
			closestEnemy.GetComponent<Ship>().DestroyShip();

		Earth.ShootLaser(closestEnemy.GetChild(0).position, 0.1f);
    }
}
