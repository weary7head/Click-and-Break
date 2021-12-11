using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BubbleSpawner : MonoBehaviour
{
    public event Action<Bubble> Spawned;

    [Header("Spawn settings")]
    [SerializeField] private float _spawnRate;
    [SerializeField] private float _minSpawnPointX;
    [SerializeField] private float _maxSpawnPointX;
    [Header("Reference for Bubble Object")]
    [SerializeField] private Bubble _bubble;

    private Transform _transform;
    private float _nextTimeToSpawn;

    private void Awake()
    {
        _transform = transform;
        _nextTimeToSpawn = 0;
    }

    private void Update()
    {
        if (CheckTimeForSpawn())
        {
            SpawnBubble(_bubble);
        }
    }

    private void SpawnBubble(Bubble bubbleObject)
    {
        Bubble bubble = Instantiate(bubbleObject, new Vector3(_transform.position.x, _transform.position.y, Random.Range(_minSpawnPointX, _maxSpawnPointX)), Quaternion.identity);
        Spawned?.Invoke(bubble);
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
