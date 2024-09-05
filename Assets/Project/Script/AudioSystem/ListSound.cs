using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioClipo
{
    public string name;
    public AudioClip clip;
    public float minPitch=1;
    public float maxPitch=1;
    [Range(0,100)]public float defaultVolume = 50;
}
[CreateAssetMenu]
public class ListSound : ScriptableObject
{
    [SerializeField] private List<AudioClipo> clips = new List<AudioClipo>();
    public List<AudioClipo> Clips { get => clips; set => clips = value; }

    public AudioClipo GetAudioClip(string name) 
    {
        name = name.ToLower();
        foreach (AudioClipo clip in clips)
        {
            if (clip.name.ToLower() == name)
            {
                return clip;
            }
        }
        Debug.LogWarning("Звука"+ name + "Нету в списке");
        return default;
    }
}
