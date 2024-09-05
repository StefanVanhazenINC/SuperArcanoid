using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Paddle : MonoBehaviour
{
    [SerializeField] private Transform _ballStartPoint;
    [SerializeField] private Ball _ball;
    [SerializeField] private float _maxbounceAngle = 75f;
    [SerializeField] private float _ballForce = 50;
    [SerializeField] private PlayerSetting _setting;
    [SerializeField] private UnityEvent _paddleHitBall;
    private bool _gameIsStart = true;
    private IInput _input;
    private InputHandler _inputHandler;

    private Transform _transform;
    private Vector2 _paddlePosition;
    private Vector2 _contactPoint;
    private Quaternion _rotation;
    public bool GameIsStart { get => _gameIsStart; set => _gameIsStart = value; }
    private void Awake()
    {
        Construct();
    }
    private void Construct()
    {
        _input = new PcInput();
        _inputHandler = new InputHandler(_input, _setting, transform);
        _input.OnClickDown += ShootBall;
        _transform = transform;
        _ball.OnDeath.AddListener(RestartBall);
        RestartBall();
    }
    
    private void Update()
    {
        if (_gameIsStart) 
        {
            _input.InputRead();
        }
    }
    public void ShootBall() 
    {
        _ball.StartBall(Vector2.up * _ballForce);
    }
    public void RestartBall() 
    {
        _ball.Restart(_ballStartPoint.localPosition,_transform);
    }
   

 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball ball)) 
        {
            _paddlePosition = _transform.position;
            _contactPoint = collision.GetContact(0).point;

            float t_offset = _paddlePosition.x - _contactPoint.x;
            float t_width = collision.otherCollider.bounds.size.x/2;
           

            float t_currentAngle = Vector2.SignedAngle(Vector2.up, ball.GetVelocity);
            float t_bounceAngle = (t_offset / t_width) * _maxbounceAngle;
            float newAngle = Mathf.Clamp(t_currentAngle + t_bounceAngle, -_maxbounceAngle, _maxbounceAngle);

            _rotation = Quaternion.AngleAxis(newAngle, Vector3.forward) ;

            ball.AddVelocity(_rotation*Vector2.up);
            _paddleHitBall?.Invoke();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Vector3.zero + (Vector3.right * _setting.XClampScreenPositive), 0.5f);
        Gizmos.DrawWireSphere(Vector3.zero + (Vector3.up* _setting.YClampScreenPositive), 0.5f);
        Gizmos.DrawWireSphere(Vector3.zero + (Vector3.right * _setting.XClampScreenNegative), 0.5f);
        Gizmos.DrawWireSphere(Vector3.zero + (Vector3.up * _setting.YClampScreenNegative), 0.5f);
    }
}
