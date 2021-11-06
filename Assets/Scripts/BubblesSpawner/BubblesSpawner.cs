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
    [SerializeField] private float _spawnRate;
    [SerializeField] private GameObject _bubble;
    
    private bool IsReadyToSpawn => CheckTimeForSpawn();
    private float _speed;
    private float _nextTimeToSpawn;
    private bool _isGameEnding;
    
    private void Awake()
    {
        _speed = 1;
        _nextTimeToSpawn = 0;
        _isGameEnding = false;
    }

    private void Start()
    {
        StartCoroutine(ChangeSpeed());
    }

    private void Update()
    {
        SpawnBubble(_bubble);
    }

    private IEnumerator ChangeSpeed()
    {
        while (_isGameEnding == false)
        {
            _speed += _valueOfSpeedIncrease;
            yield return new WaitForSecondsRealtime(_secondsForChangeSpeed);
            SpeedChanged?.Invoke(_speed);
        }
    }

    private void SpawnBubble(GameObject bubble)
    {
        if (IsReadyToSpawn)
        {
            Instantiate(bubble);
        }
    }

    private bool CheckTimeForSpawn()
    {
        if (Time.time > _nextTimeToSpawn)
        {
            _nextTimeToSpawn = Time.time + 1f / _spawnRate;
            return true;
        }

        return false;
    }
}
