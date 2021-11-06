using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

[RequireComponent(typeof(MeshRenderer))]
public class Bubble : MonoBehaviour
{
    [Header("Properties limits")]
    [SerializeField] private float _minimumSpeed = 1f;
    [SerializeField] private float _maximumSpeed = 2f;
    [SerializeField] private int _minimumDamage = 1;
    [SerializeField] private int _maximumDamage = 5;
    [SerializeField] private int _minimumPoints = 1;
    [SerializeField] private int _maximumPoints = 10;
    [SerializeField, Range(0, 255)] private int _minimumColor = 0;
    [SerializeField, Range(0, 255)] private int _maximumColor = 255;
    [Header("Y value of bubble's destroyer")]
    [SerializeField] private float _yDestination;
    [Header("Particle effect after the death of the bubble")]
    [SerializeField] private GameObject _particleObject;
    [Header("Reference for spawner")] 
    [SerializeField] private BubblesSpawner _bubblesSpawner;

    private Transform _transform;
    private float _speed;
    private int _damage;
    private int _points;
    private Color _color;
    private MeshRenderer _meshRenderer;
    private Vector3 _destination;

    private void Awake()
    {
        _transform = transform;
        _speed = Random.Range(_minimumSpeed, _maximumSpeed);
        _damage = Random.Range(_minimumDamage, _maximumDamage);
        _points = Random.Range(_minimumPoints, _maximumPoints);
        _color = new Color(Random.Range(_minimumColor, _maximumColor), Random.Range(_minimumColor, _maximumColor), Random.Range(_minimumColor, _maximumColor));
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnEnable()
    {
        _bubblesSpawner.SpeedChanged += ChangeSpeed;
    }

    private void Start()
    {
        _meshRenderer.material.color = _color;
        _destination = _transform.position;
        _destination.y += _yDestination;
    }

    private void Update()
    {
        _transform.position = Vector3.MoveTowards(_transform.position, _destination, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (TryGetComponent(out BubblesDestroyer bubblesDestroyer))
        {
            Destroy(gameObject);
        }
    }

    private void OnDisable()
    {
        _bubblesSpawner.SpeedChanged -= ChangeSpeed;
    }

    private void OnDestroy()
    {
        Instantiate(_particleObject);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void ChangeSpeed(float speed)
    {
        _speed *= speed;
    }
}