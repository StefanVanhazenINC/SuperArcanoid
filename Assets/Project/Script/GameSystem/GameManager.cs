using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    //жизни и ссылка на шарик 

    [SerializeField] private int _playerHealth;
    [SerializeField] private LevelGeneration _levelGeneration;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private Ball _ball;
    [SerializeField] private Paddle _paddle;
    [SerializeField] private WinDialog _winDialog;
    [SerializeField] private LoseDialog _loseDialog;

    private int _health;
    [HideInInspector] public UnityEvent<int> OnUpdateHealth;

    

    //int ballInGame
    public int Health 
    {
        get => _health; 
        set 
        {
            _health = value;
            OnUpdateHealth?.Invoke(value);
        }
    }

    private void Start()
    {
        StartGame();
        Construct();
    }
    private void Construct() 
    {
        _ball.OnDeath.AddListener(CheckLose);
    }
    public void StartGame() 
    {
        _levelGeneration.ClearLevel();
        _paddle.RestartBall();
        Health = _playerHealth;
        _paddle.GameIsStart = true;
        _levelGeneration.LoadLevel(0);
        _winDialog.CloseDialog();
        _loseDialog.CloseDialog();
    }
   
    private void CheckLose() 
    {
        //ballinGame--;
        // if(ballInGame<=0)
        Health--;
        if (Health <= 0) 
        {
            _ball.gameObject.SetActive(false);
            Lose();
        }
    }

    public void LoadLevel()
    {
        _paddle.RestartBall();
    }
    public void Lose() 
    {
        Debug.Log("Lose");

        _paddle.GameIsStart = false;
        LoseGameWindodOpen();
    }
    public void LoseGameWindodOpen()
    {
        _loseDialog.OpenDialog(_scoreManager.Score);
    }
    public void Win() 
    {
        Debug.Log("Win");
        _ball.gameObject.SetActive(false);
        _paddle.GameIsStart = false;
        WinGameWindowOpen();
    }
    public void WinGameWindowOpen()
    {
        _winDialog.OpenDialog(_scoreManager.Score);
    }
    public void QuitGame() 
    {
        Application.Quit();
    }
    
}
