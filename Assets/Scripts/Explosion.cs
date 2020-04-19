using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
	private void Awake()
	{
		Reder.MakeRed("red");
	}

	public void DestroyExplosion()
	{
		Destroy(gameObject);
	}
}
