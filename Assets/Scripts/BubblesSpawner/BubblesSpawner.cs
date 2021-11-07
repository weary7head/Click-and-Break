using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BubblesSpawner : MonoBehaviour
{
    public event Action<float> SpeedChanged;

    [SerializeField] private float _valueOfSpeedIncrease;
    [SerializeField] private float _spawnRate;
    [SerializeField] private float _changeSpeedRate;
    [SerializeField] private GameObject _bubble;
    [SerializeField] private float _minSpawnPointX;
    [SerializeField] private float _maxSpawnPointX;

    private bool IsReadyToChangeSpeed => CheckTimeForChangeSpeed();
    private bool IsReadyToSpawn => CheckTimeForSpawn();
    private float _speed;
    private float _nextTimeToSpawn;
    private float _nextTimeToChangeSpeed;
    private Transform _transform;
    
    private void Awake()
    {
        _speed = 1;
        _nextTimeToSpawn = 0;
        _transform = transform;
    }

    private void Update()
    {
        SpawnBubble(_bubble);
        ChangeSpeed();
    }

    private void ChangeSpeed()
    {
        if (IsReadyToChangeSpeed)
        {
            _speed += _valueOfSpeedIncrease;
            SpeedChanged?.Invoke(_speed);
        }
    }

    private void SpawnBubble(GameObject bubble)
    {
        if (IsReadyToSpawn)
        {
            Instantiate(bubble, new Vector3(_transform.position.x ,_transform.position.y, Random.Range(_minSpawnPointX, _maxSpawnPointX)), Quaternion.identity).SetActive(true);
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

    private bool CheckTimeForChangeSpeed()
    {
        if (Time.time > _nextTimeToChangeSpeed)
        {
            _nextTimeToChangeSpeed = Time.time + 1f / _changeSpeedRate;
            return true;
        }

        return false;
    }
}
