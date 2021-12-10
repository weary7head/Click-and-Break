using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BubblesHolder : MonoBehaviour
{
    [SerializeField] private float _valueOfSpeedIncrease;
    [SerializeField] private float _spawnRate;
    [SerializeField] private float _changeSpeedRate;
    [SerializeField] private Bubble _bubble;
    [SerializeField] private float _minSpawnPointX;
    [SerializeField] private float _maxSpawnPointX;
    [Header("Reference for Player")]
    [SerializeField] private Player _player;

    private float _speed;
    private float _nextTimeToSpawn;
    private float _nextTimeToChangeSpeed;
    private Transform _transform;

    private List<Bubble> _bubbles;
    
    private void Awake()
    {
        _speed = 1;
        _nextTimeToSpawn = 0;
        _transform = transform;
        _bubbles = new List<Bubble>();
    }

    private void Update()
    {
        if (CheckTimeForSpawn())
        {
            SpawnBubble(_bubble);
        }
        if (CheckTimeForChangeSpeed())
        {
            ChangeSpeed();
        }
    }

    private void ChangeSpeed()
    {
        _speed += _valueOfSpeedIncrease;
        foreach (Bubble bubble in _bubbles)
        {
            bubble.ChangeSpeed(_speed);
        }  
    }

    private void SpawnBubble(Bubble bubbleObject)
    {
        Bubble bubble = Instantiate(bubbleObject, new Vector3(_transform.position.x, _transform.position.y, Random.Range(_minSpawnPointX, _maxSpawnPointX)), Quaternion.identity);
        bubble.Clicked += BubbleClicked;
        bubble.Destroyed += BubbleDestroyed;
        _bubbles.Add(bubble);
    }

    private void BubbleDestroyed(Bubble bubble)
    {
        _player.GetDamage(bubble.Damage);
        _bubbles.Remove(bubble);
        bubble.Clicked -= BubbleClicked;
        bubble.Destroyed -= BubbleDestroyed;
    }

    private void BubbleClicked(Bubble bubble)
    {
        _player.AddPoints(bubble.Points);
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
