using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilesDestroyer : MonoBehaviour
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

    public static void DestroyClosest()
    {
        Transform MissilesHolder = GameManager.Instance.MissilesHolder;
		if (MissilesHolder.childCount == 0) // No missiles found, so nothing to do here
			return;

		// Find closest missile...
		Transform closestMissile = null;
		float minDist = -1f;
		for (int i = 0; i < Instance.MissilesHolder.childCount; i++)
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
    }
}
