using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] _mainTheme;
    AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        MusicRandom();
    }
    void MusicRandom()
    {
        int RandInd = Random.Range(0, _mainTheme.Length);
        _audioSource.PlayOneShot(_mainTheme[RandInd]);
    }
}
