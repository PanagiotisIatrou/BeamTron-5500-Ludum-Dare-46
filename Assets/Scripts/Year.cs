using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Year : MonoBehaviour
{
    // Singleton
    private static Year _instance;
    public static Year Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Year>();
            }

            return _instance;
        }

    }

    public TextMeshProUGUI YearText;
    private int year = 2025;
    private float yearTimeMax = 5f; // Length of a year in seconds
    private float yearTimer = 0f;

    private void Update()
    {
        yearTimer += Time.deltaTime;
        if (yearTimer >= yearTimeMax)
        {
            yearTimer = 0f;
            year++;
            YearText.SetText("YEAR: " + year);
        }
    }

    public static int GetYear()
    {
        return Instance.year;
    }
}
