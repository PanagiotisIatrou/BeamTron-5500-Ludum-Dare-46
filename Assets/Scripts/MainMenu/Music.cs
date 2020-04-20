using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(IEStartMusic());
    }

    public void StopMusic()
    {
        StartCoroutine(IEStopMusic());
    }

    private IEnumerator IEStopMusic()
    {
        while (audioSource.volume > 0f)
        {
            audioSource.volume -= Time.deltaTime / 0.8f;
            yield return null;
        }
    }

    private IEnumerator IEStartMusic()
    {
        while (audioSource.volume < 1f)
        {
            audioSource.volume += Time.deltaTime / 2f;
            yield return null;
        }
    }
}
