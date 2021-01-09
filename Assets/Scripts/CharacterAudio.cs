using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAudio : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] _forestFootStepClips;
    [SerializeField]
    private AudioClip[] _sneakyFootStepClips;
    [SerializeField]
    private AudioClip[] _slideClips;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();    
    }

    private void Step()
    {
        var clip = _forestFootStepClips[Random.Range(0, _forestFootStepClips.Length)];
        _audioSource.PlayOneShot(clip);
    }

    private void Slide()
    {
        var clip = _slideClips[Random.Range(0, _slideClips.Length)];
        _audioSource.PlayOneShot(clip);
    }

    private void SneakyStep()
    {
        var clip = _sneakyFootStepClips[Random.Range(0, _sneakyFootStepClips.Length)];
        _audioSource.PlayOneShot(clip);
    }
}
