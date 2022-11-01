using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YFrameWork;

public class AudioManager : ClickMouseController
{
    private AudioManager() { }
    public static AudioManager Instance {
        get
        {
            return _instance;
        }
     }

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        _hitClip = Resources.Load<AudioClip>("AudioClips/Hit");
        _errorClip = Resources.Load<AudioClip>("AudioClips/Error");
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayHitAudio()
    {
        _audioSource.clip = _hitClip;
        _audioSource.Play();
    }

    public void PlayErrorAudio()
    {
        _audioSource.clip = _errorClip;
        _audioSource.Play();
    }

    AudioClip _hitClip;
    AudioClip _errorClip;
    AudioSource _audioSource;
    private static AudioManager _instance;

}
