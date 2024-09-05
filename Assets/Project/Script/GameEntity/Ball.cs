using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _speed = 50;
    [SerializeField] private float _maxSpeed = 50;
    [SerializeField] private Transform _defaultParent;
    public UnityEvent OnDeath;
    private Rigidbody2D _rb;
    private Transform _transform;
    private bool _ballInGame = false;
    public Vector2 GetVelocity { get { return _rb.velocity; } }

    public bool BallInGame { get => _ballInGame; set => _ballInGame = value; }

    private void Constructor() 
    {
        _rb = GetComponent<Rigidbody2D>();
        _transform = transform;
    }
    private void Awake()
    {
        Constructor();
       
    }
    private void Update()
    {
        ClampSpeed();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SetRandomTrajectory();
    }
    private void ClampSpeed() 
    {
        if (_rb.velocity.magnitude>_maxSpeed) 
        {
            _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, _maxSpeed);
        }
    }
    public void StartBall(Vector3 velocity) 
    {
        _rb.isKinematic = false;
        _transform.SetParent(_defaultParent);
        SetVelocity(velocity);
    }
    public void AddVelocity(Vector3 velocity) 
    {
        _rb.velocity = velocity * GetVelocity.magnitude;
    }
    public void SetVelocity(Vector3 velocity) 
    {
        _rb.velocity = velocity;
    }
    public void Restart(Vector2 startPosition,Transform parent) 
    {
        gameObject.SetActive(true);
        _rb.isKinematic = true;
        AddVelocity(Vector2.zero);
        _transform.SetParent(parent);
        _transform.localPosition = startPosition;
    }
    public void Death() 
    {
        OnDeath?.Invoke();
    }
    private void SetRandomTrajectory() 
    {
        Vector2 t_force = Vector2.zero;
        t_force.x =  Random.Range(-1f, 1f);
        t_force.y = -1f;
        _rb.AddForce(t_force.normalized * _speed);
    }
    
}
