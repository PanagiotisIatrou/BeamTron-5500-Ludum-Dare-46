using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    public GameObject MissilePrefab;
    private Vector2 spawnXBounds = new Vector2(-7.5f, 7.5f);
    private Vector2 spawnYBounds = new Vector2(-4f, 6f);
    private float spawnTimeMax = 5f;
    private float spawnTimer = 0f;

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnTimeMax)
        {
            spawnTimer = 0f;
            Instantiate(MissilePrefab, GetRandomPosOut(), Quaternion.identity);
        }
    }

    private Vector2 GetRandomPosOut()
    {
        Vector2 pos;
        int r0 = Random.Range(0, 2);
        int r1 = Random.Range(0, 2);
        if (r0 == 0)
        {
            pos.x = Random.Range(spawnXBounds.x, spawnXBounds.y);
            if (r1 == 0)
                pos.y = spawnYBounds.x;
            else
                pos.y = spawnYBounds.y;
        }
        else
        {
            if (r1 == 0)
                pos.x = spawnXBounds.x;
            else
                pos.x = spawnXBounds.y;

            pos.y = Random.Range(spawnYBounds.x, spawnYBounds.y);
        }

        return pos;
    }
}
