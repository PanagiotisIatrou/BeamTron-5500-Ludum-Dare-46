using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilesDestroyer : MonoBehaviour
{

    public static void DestroyClosest()
    {
        Transform MissilesHolder = GameManager.Instance.EnemiesHolder.GetChild(0);
		if (MissilesHolder.childCount == 0) // No missiles found, so nothing to do here
			return;

		// Find closest missile...
		Transform closestMissile = null;
		float minDist = -1f;
		for (int i = 0; i < MissilesHolder.childCount; i++)
        {
			Transform missile = MissilesHolder.GetChild(i);
			float dist = Vector2.Distance(Earth.Instance.transform.position, missile.position);
			if (i == 0 ||  dist < minDist)
			{
				minDist = dist;
				closestMissile = missile;
			}
		}

		// ...and destroy it
		closestMissile.GetComponent<Missile>().DestroyMissile();
		Earth.ShootLaser(closestMissile.GetChild(0).position, 0.1f);
    }
}
