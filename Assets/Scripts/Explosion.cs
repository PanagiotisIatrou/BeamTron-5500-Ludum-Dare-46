using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
	public AudioClip small;
	public AudioClip big;

	public void PlayExplosionSound(string type)
	{
		if (type == "small")
			AudioSource.PlayClipAtPoint(small, transform.position);
		else if (type == "big")
			AudioSource.PlayClipAtPoint(big, transform.position);
	}

	public void DestroyExplosion()
	{
		Destroy(gameObject);
	}
}
