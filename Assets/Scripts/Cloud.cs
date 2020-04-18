using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private float speed = 0.05f;

    private void Update()
    {
        if (transform.localPosition.x > 1.8f)
            Destroy(gameObject);

        transform.position += transform.right * speed * Time.deltaTime;
    }
}
