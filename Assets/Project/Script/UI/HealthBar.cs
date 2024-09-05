using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HealthBar 
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private TMP_Text _healthCounter;

    public HealthBar(GameManager gameManager, TMP_Text healthCounter)
    {
        _gameManager = gameManager;
        _healthCounter = healthCounter;
        _gameManager.OnUpdateHealth.AddListener(UpdateHealthCounter);
    }

  

    private void UpdateHealthCounter(int value)
    {
        _healthCounter.text = "Health:" + value;
    }
}
