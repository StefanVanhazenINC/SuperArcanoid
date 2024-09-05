using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int _score;
    [HideInInspector] public UnityEvent<int> OnUpdateScore;

 
    public int Score 
    { 
        get => _score; 
        set 
        {
            _score = value;
            OnUpdateScore?.Invoke(_score);
        }
    }
    private void Awake()
    {
        Constructor();
    }
    public void Constructor()
    {
        Score = 0;
    }
    public void AddedScore(int point) 
    {
        Score += point;
    }
}
