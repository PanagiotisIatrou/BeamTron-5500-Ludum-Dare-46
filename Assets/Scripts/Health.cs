using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
	// Singleton
	private static Health _instance;
	public static Health Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = GameObject.FindObjectOfType<Health>();
			}

			return _instance;
		}
	}

	public Slider slider;
	private int maxHealth = 100;
	private int health;

	private void Start()
	{
		health = maxHealth;
	}

	public static int GetHealth()
	{
		return Instance.health;
	}

	public static void SetHealth(int amount)
	{
		Instance.health = amount;
		Instance.health = Mathf.Clamp(Instance.health, 0, Instance.maxHealth);
		Instance.slider.value = (float)Instance.health / Instance.maxHealth;
		Earth.UpdateSprite();
	}

	public static void TakeDamage(int amount)
	{
		SetHealth(Instance.health - amount);
	}

	public static void Heal(int amount)
	{
		SetHealth(Instance.health + amount);
	}
}
