using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelDisplay 
{
    [SerializeField] private LevelGeneration _levelGeneration;
    [SerializeField] private TMP_Text _levelCounter;

    public LevelDisplay(LevelGeneration levelGeneration, TMP_Text levelCounter)
    {
        _levelGeneration = levelGeneration;
        _levelCounter = levelCounter;
        _levelGeneration.OnUpdateLevelIndex.AddListener(UpdateLevelCounter);
    }

    

    private void UpdateLevelCounter(int value)
    {
        _levelCounter.text = "Level:" + value;
    }
}
