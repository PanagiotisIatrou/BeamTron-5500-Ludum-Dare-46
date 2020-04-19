using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oxygen : MonoBehaviour
{
    // Singleton
    private static Oxygen _instance;
    public static Oxygen Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Oxygen>();
            }

            return _instance;
        }
    }

    public Slider slider;
    private float maxOxygen = 10f;
    private float oxygen;
    private float oxygenDropRate = 0.25f;

    private void Start()
    {
        oxygen = maxOxygen;
    }

    private void Update()
    {
        LowerOxygen(oxygenDropRate * Time.deltaTime);
    }

    public static float GetOxygen()
    {
        return Instance.oxygen;
    }

    public static float GetOxygenPercent()
    {
        return Instance.oxygen / Instance.maxOxygen;
    }

    public static void SetOxygen(float amount)
    {
        Instance.oxygen = amount;
        Instance.oxygen = Mathf.Clamp(Instance.oxygen, 0, Instance.maxOxygen);
        Instance.slider.value = (float)Instance.oxygen / Instance.maxOxygen;
    }

    public static void LowerOxygen(float amount)
    {
        SetOxygen(Instance.oxygen - amount);
    }

    public static void IncreaseOxygen(float amount)
    {
        SetOxygen(Instance.oxygen + amount);
    }

    public static void IncreaseOxygenByPercent(float percent)
    {
        SetOxygen(Instance.oxygen + Instance.maxOxygen * percent / 100f);
    }
}
