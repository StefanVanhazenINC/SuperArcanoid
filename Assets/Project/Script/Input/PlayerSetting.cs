using UnityEngine;

[CreateAssetMenu]
public class PlayerSetting : ScriptableObject
{
    [SerializeField] private float _speed = 20;
    [SerializeField] private float _xClampScreenNegative = -8.3f;
    [SerializeField] private float _xClampScreenPositive = 8.3f;

    [SerializeField] private float _yClampScreenPositive = 4.45f;
    [SerializeField] private float _yClampScreenNegative = -4.45f;


    public float XClampScreenPositive { get => _xClampScreenPositive; }
    public float XClampScreenNegative { get => _xClampScreenNegative; }
    public float YClampScreenPositive { get => _yClampScreenPositive; }
    public float YClampScreenNegative { get => _yClampScreenNegative; }
    public float Speed { get => _speed; }
}
