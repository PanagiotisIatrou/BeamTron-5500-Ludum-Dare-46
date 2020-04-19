using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
	// Singleton
	private static Radar _instance;
	public static Radar Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = GameObject.FindObjectOfType<Radar>();
			}

			return _instance;
		}

	}

	private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public static void DeclarePeace()
    {
		Instance.anim.SetTrigger("PeaceTrigger");
	}

	public static void DeclareWave()
	{
		Instance.anim.SetTrigger("WaveTrigger");
	}
}
