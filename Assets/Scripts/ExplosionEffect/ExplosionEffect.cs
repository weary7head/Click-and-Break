using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ExplosionEffect : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    private Color _color;
    private float _destroyTime = 3;
    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        var main = _particleSystem.main;
        main.startColor = _color;
        Destroy(gameObject, _destroyTime);
    }

    public void SetColor(Color color)
    {
        _color = color;
    }
    
}
