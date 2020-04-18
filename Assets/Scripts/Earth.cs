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

    public Sprite[] EarthSprites;
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public static void UpdateSprite()
    {
        int health = Health.GetHealth();
        int spritesCount = Instance.EarthSprites.Length;
        float div = 100f / (spritesCount - 1);

        bool isAlive = false;
        for (int i = 0; i < spritesCount - 1; i++)
        {
            if (health > div * (spritesCount - i - 2))
            {
                Instance.sr.sprite = Instance.EarthSprites[i];
                isAlive = true;
                break;
            }
        }

        if (!isAlive)
            Instance.sr.sprite = Instance.EarthSprites[spritesCount - 1];
    }
}
