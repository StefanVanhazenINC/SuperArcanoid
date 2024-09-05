using System;
using UnityEngine;

public interface IInput 
{
    public event Action<float> OnChangeDirection;
    public event Action OnClickDown;

    public void InputRead();
}
