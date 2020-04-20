using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Singleton
    private static MusicPlayer _instance;
    public static MusicPlayer Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<MusicPlayer>();
            }

            return _instance;
        }

    }

    public AudioClip[] audioClips;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(IEPlayer());
    }

    private IEnumerator IEPlayer()
    {
        while (true)
        {
            int state = Earth.GetState();
            audioSource.clip = audioClips[state];
            audioSource.Play();
            while (audioSource.isPlaying)
                yield return null;


            //yield return new WaitForSeconds(audioClips[state].length);
        }
    }
}
