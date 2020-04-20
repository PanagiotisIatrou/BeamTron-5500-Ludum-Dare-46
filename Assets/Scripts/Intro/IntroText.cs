using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroText : MonoBehaviour
{
    public AudioSource audioSource;
    private float speed = 3f;
    private bool called = false;

    private void Start()
    {
        StartCoroutine(IEStartMusic());
    }

    private void Update()
    {
        if ((transform.position.z > 16f && !called) || Input.GetKeyDown(KeyCode.Return))
        {
            called = true;
            StartCoroutine(IEStopMusic());
            BlackFader.GoToScene("MainMenu", UnityEngine.SceneManagement.LoadSceneMode.Single, 3f);
        }

        transform.position += Vector3.forward * speed * Time.deltaTime;
    }

    private IEnumerator IEStopMusic()
    {
        while (audioSource.volume > 0f)
        {
            audioSource.volume -= Time.deltaTime / 3f;
            yield return null;
        }
    }

    private IEnumerator IEStartMusic()
    {
        while (audioSource.volume < 1f)
        {
            audioSource.volume += Time.deltaTime / 10f;
            yield return null;
        }
    }
}
