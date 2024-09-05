using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler
{
    public IInput _input;
    private Transform _body;
    private PlayerSetting _playerSetting;
    private Vector2 _workSpace;
    public InputHandler(IInput input, PlayerSetting setting, Transform body)
    {
        _input = input;
        _body = body;
        _playerSetting = setting;   
        _input.OnChangeDirection += OnChangeDirection;
    }

    public void OnChangeDirection(float position) 
    {
        _workSpace = new Vector3(position, 0, 0) * _playerSetting.Speed * Time.deltaTime;
        _body.Translate(_workSpace);
        _body.transform.position = ClampPosition(_body.transform.position);
    }
   
    public Vector3 ClampPosition(Vector3 position)
    {
        position.x = Mathf.Clamp(position.x, _playerSetting.XClampScreenNegative, _playerSetting.XClampScreenPositive);
        position.y = Mathf.Clamp(position.y, _playerSetting.YClampScreenNegative, _playerSetting.YClampScreenPositive);
        position.z = 0;
        return position;
    }

}
