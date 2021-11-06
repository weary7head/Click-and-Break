using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BubblesSpawner : MonoBehaviour
{
    public event Action<float> SpeedChanged;
    
    [SerializeField] private float _secondsForChangeSpeed;
    [SerializeField] private float _valueOfSpeedIncrease;
    
    private float _speed;
    
    private void Awake()
    {
        _speed = 1;
    }

    private void Start()
    {
        StartCoroutine(ChangeSpeed());
    }

    private void Update()
    {
        if (expr)
        {
            
        }
    }

    private IEnumerator ChangeSpeed()
    {
        _speed += _valueOfSpeedIncrease;
        yield return new WaitForSecondsRealtime(_secondsForChangeSpeed);
        SpeedChanged?.Invoke(_speed);
    }
}
