using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreCounter 
{
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private TMP_Text _scoreText;

    public ScoreCounter(ScoreManager scoreManager, TMP_Text scoreText)
    {
        _scoreManager = scoreManager;
        _scoreText = scoreText;
        _scoreManager.OnUpdateScore.AddListener(UpdateScore);
    }

  
    private void UpdateScore(int value)
    {
        _scoreText.text = "Score:" + value;
    }
}
