using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    // Singleton
    private static Earth _instance;
    public static Earth Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Earth>();
            }

            return _instance;
        }

    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
