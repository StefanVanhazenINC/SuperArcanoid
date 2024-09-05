using System;
using UnityEngine;

public class PcInput : IInput
{
    private float _workSpace;

    public event Action<float> OnChangeDirection;
    public event Action OnClickDown;

    public void InputRead()
    {
        _workSpace = Input.GetAxisRaw("Horizontal");
        OnChangeDirection?.Invoke(_workSpace);
        if (Input.GetButtonDown("Jump"))
        {
            OnClickDown?.Invoke();
        }
    }
}
