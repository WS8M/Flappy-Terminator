using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour, IPoolable, IInteractable
{
    [SerializeField] private Rigidbody2D _rigidbody;
    private float _speed;

    public event Action<IPoolable> Removed;
    
    private void Update()
    {
        _rigidbody.velocity = gameObject.transform.right * _speed;
    }

    public void Activate(Vector3 startPosition, Quaternion startRotation, float speed)
    {
        _speed = speed;
        gameObject.transform.position = startPosition;
        gameObject.transform.rotation = startRotation;
        gameObject.SetActive(true);
    }
    
    public void Deactivate()
    {
        Removed?.Invoke(this);
    }
}