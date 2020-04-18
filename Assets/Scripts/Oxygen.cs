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
    private int maxOxygen = 100;
    private int oxygen;

    private void Start()
    {
        oxygen = maxOxygen;
    }

    public static void SetOxygen(int amount)
    {
        Instance.oxygen = amount;
        Instance.oxygen = Mathf.Clamp(Instance.oxygen, 0, Instance.maxOxygen);
        Instance.slider.value = (float)Instance.oxygen / Instance.maxOxygen;
    }

    public static void LowerOxygen(int amount)
    {
        SetOxygen(Instance.oxygen - amount);
    }
}
