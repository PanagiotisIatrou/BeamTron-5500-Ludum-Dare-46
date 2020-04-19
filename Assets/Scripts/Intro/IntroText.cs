using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroText : MonoBehaviour
{
    private float speed = 3f;
    private bool called = false;

    private void Update()
    {
        if (transform.position.z > 16f && !called)
        {
            called = true;
            BlackFader.GoToScene("MainMenu", UnityEngine.SceneManagement.LoadSceneMode.Single, 3f);
        }

        transform.position += Vector3.forward * speed * Time.deltaTime;
    }
}
