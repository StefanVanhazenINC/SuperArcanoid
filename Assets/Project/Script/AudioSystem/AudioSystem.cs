using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AudioSystem : MonoBehaviour
{
    public static AudioSystem instance;
    [SerializeField] private GameSetting _gameSetting;
    [SerializeField] private ListSound _listSound;
    [SerializeField] private AudioSource sourcePrefab;
    private List<AudioSource> sources = new List<AudioSource>();


    private void Awake()
    {
        if (instance != null) Destroy(this);
        else instance = this;
    }
    public void PlaySound(string clipName)
    {
        AudioSource source = GetAudioSource();
        AudioClipo tempClip = GetAudioClip(clipName);
        source.clip = tempClip.clip;
        source.pitch = Random.Range(tempClip.minPitch, tempClip.maxPitch);
        source.volume =(tempClip.defaultVolume / 100) * (_gameSetting.SoundValue / 100);
        source.Play();

    }

    private AudioSource GetAudioSource()
    {
        foreach (AudioSource source in sources)
        {
            if(!source.isPlaying)
            {
                return source;
            }
        }

        sources.Add(Instantiate(sourcePrefab, transform));
        sourcePrefab.volume = _gameSetting.SoundValue / 100;
        return sources[sources.Count - 1];

    }

    private AudioClipo GetAudioClip(string name)
    {
        return _listSound.GetAudioClip(name);   
    }

}
