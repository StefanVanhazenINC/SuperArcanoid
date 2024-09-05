using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSystem : MonoBehaviour
{

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameSetting _gameSetting;
    private void Start()
    {
        ChangeVolueme();
        PlayTrack();
    }
    public void PlayTrack() 
    {
        _audioSource.Play();
    }
    public void ChangeVolueme() 
    {
        _audioSource.volume = _gameSetting.MusicValue/100;
    }
}
