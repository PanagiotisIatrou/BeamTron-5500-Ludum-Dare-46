using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsSpawner : MonoBehaviour
{
    public GameObject CloudPrefab;
    private float spawnTimeMax = 20f;
    private float spawnTimer = 0f;

    private void Start()
    {
        spawnTimer = spawnTimeMax;
    }

    private void Update()
    {
        // Rotate clouds
        transform.rotation = Earth.Instance.transform.rotation;

        if (Health.GetHealth() == 0) // We are dead so no clouds
            return;

        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnTimeMax)
        {
            spawnTimer = 0f;
            GameObject cloud = Instantiate(CloudPrefab, Vector3.zero, Quaternion.identity, transform);
            cloud.transform.localPosition = new Vector3(-1.8f, Random.Range(-1.2f, 1.2f), -1f);
            cloud.transform.localRotation = Quaternion.identity;
        }
    }
}
