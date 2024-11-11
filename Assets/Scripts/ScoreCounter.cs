using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private float _value;
    
    public event Action<float> ScoreChanged;

    public void AddScore(float value)
    {
        if(value <= 0)
            return;
        
        _value += value;
        ScoreChanged?.Invoke(_value);
    }

    public void Reset()
    {
        _value = 0;
        ScoreChanged?.Invoke(0);
    }
}
