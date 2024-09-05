using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameSetting : ScriptableObject
{
    [SerializeField,Range(0,100)] private float _soundValue = 100;
    [SerializeField, Range(0, 100)] private float _musicValue = 100;
    public float SoundValue { get => _soundValue; set => _soundValue = value; }
    public float MusicValue { get => _musicValue; set => _musicValue = value; }
}
