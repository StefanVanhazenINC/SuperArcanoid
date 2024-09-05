using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Brick : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _scorePoint = 100;
    [SerializeField] private Gradient _brickVisual;
    [SerializeField] private SpriteRenderer _spriteRender;
    public UnityEvent<int> OnDeathBrickInt;
    public UnityEvent OnDeathBrick;
    public UnityEvent OnHitBrick;
    private int _health;

    public int MaxHealth { get => _maxHealth; }
    public int ScorePoint { get => _scorePoint;  }

    public void SetBrick(int maxHealth,int score)
    {
        _maxHealth = maxHealth;
        _scorePoint = score;
    }
    private void Constructor()
    {
        _health = _maxHealth;
        UpdateVisual();
    }
    private void OnEnable()
    {
        Constructor();
    }
   
    private void UpdateVisual() 
    {
        _spriteRender.color = _brickVisual.Evaluate(((float)_health / _brickVisual.colorKeys.Length));
    }
    public void Hit() 
    {
        _health--;
        OnHitBrick?.Invoke();
        UpdateVisual();
        CheckDeath();
    }
    public void CheckDeath() 
    {
        if (_health<=0) 
        {
            OnDeathBrickInt?.Invoke(_scorePoint);
            OnDeathBrick?.Invoke();
            gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Ball>())
        {
            Hit();
        }
    }
}
