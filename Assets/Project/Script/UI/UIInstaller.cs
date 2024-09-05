using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIInstaller : MonoBehaviour
{
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private LevelGeneration _levelGeneration;
    [SerializeField] private GameManager _gameManager;

    [SerializeField] private TMP_Text _scoreField;
    [SerializeField] private TMP_Text _levelField;
    [SerializeField] private TMP_Text _healthField;

    private HealthBar _healthBar;
    private LevelDisplay _levelDisplay;
    private ScoreCounter _scoreDisplay;

    private void Awake() 
    {
        Constructor();
    }
    private void Constructor() 
    {
        _healthBar = new HealthBar(_gameManager, _healthField) ;
        _levelDisplay = new LevelDisplay(_levelGeneration, _levelField);
        _scoreDisplay = new ScoreCounter(_scoreManager, _scoreField);
    }

}
