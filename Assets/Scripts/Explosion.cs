using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
	public AudioClip small;
	public AudioClip big;

	public void PlayExplosionSound(string type)
	{
		Vector3 pos = transform.position;
		pos.z = -10;
		if (type == "small")
			AudioSource.PlayClipAtPoint(small, pos);
		else if (type == "big")
			AudioSource.PlayClipAtPoint(big, pos);
	}

	public void DestroyExplosion()
	{
		Destroy(gameObject);
	}
}
