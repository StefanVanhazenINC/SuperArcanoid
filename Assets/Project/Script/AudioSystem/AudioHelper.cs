using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHelper : MonoBehaviour
{
    public void PlaySound(string soundName) 
    {
        if (AudioSystem.instance != null)
        {
            AudioSystem.instance.PlaySound(soundName);
        }
        else 
        {
            Debug.LogWarning("Нету звуковой системы");
        }
    }
}
