using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{

	// Singleton
	private static Shaker _instance;
	public static Shaker Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = GameObject.FindObjectOfType<Shaker>();
			}

			return _instance;
		}
	}

	private Transform cameraTransform;
	private float shakeLength = 0.2f;
	private float shakeTimer = 0;
	private float shakeAmount = 0.05f;
	private float shakeSpeed = 40f;
	private bool isShaking = false;
	private bool shakeOnce = false;
	Vector3 originalPos;
	Vector3 newPos;

	private void Awake()
	{
		shakeTimer = shakeLength;
	}

	private void Start()
	{
		cameraTransform = Camera.main.transform;
		originalPos = cameraTransform.position;
	}

	private void Update()
	{
		if (shakeOnce)
		{
			shake();
		}
	}

	public static void Shake(float magnitude)
	{
		Instance.shakeAmount = magnitude;

		Instance.shakeOnce = true;
		Instance.shakeTimer = Instance.shakeLength;
		Instance.newPos = Instance.cameraTransform.position;
	}

	private void shake()
	{
		if (shakeTimer > 0)
		{
			isShaking = true;

			if (Vector3.Distance(newPos, cameraTransform.position) <= shakeAmount / 30) { newPos = originalPos + Random.insideUnitSphere * shakeAmount; }

			cameraTransform.position = Vector3.Lerp(cameraTransform.position, newPos, Time.deltaTime * 1 * shakeSpeed);

			shakeTimer -= Time.deltaTime;
		}
		else
		{
			shakeTimer = 0f;
			cameraTransform.position = originalPos;
			isShaking = false;
			shakeOnce = false;
		}
	}
}
