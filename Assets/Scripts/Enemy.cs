using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IInteractable, IPoolable
{
    [SerializeField] private Attacker _attacker;
    [SerializeField] private CollisionHandler _collisionHandler;
    [SerializeField] private float _attackDelay;
    [SerializeField] private float _reward = 1f;

    private float _currentTime;
    private bool _isActive;
    
    public event Action<IPoolable> Removed;
    public event Action<float> DestroyedByPlayer;

    private void OnEnable() => 
        _collisionHandler.CollisionDetected += OnCollisionWithInteract;

    private void OnDisable() => 
        _collisionHandler.CollisionDetected -= OnCollisionWithInteract;

    private void Update()
    {
        if (_isActive == false)
            return;
        
        if (_currentTime > 0)
        {   
            _currentTime -= Time.deltaTime;
        }
        else
        {
            _attacker.Attack();
            _currentTime = _attackDelay;
        }
    }

    public void Activate()
    {
        _currentTime = _attackDelay;
        _isActive = true;
    }
    
    public void Deactivate()
    {
        _isActive = false;
        Removed?.Invoke(this);
    }
    
    public void Reset() => 
        _attacker.Reset();

    private void OnCollisionWithInteract(IInteractable interactable)
    {
        if (interactable as Bullet)
        {
            DestroyedByPlayer?.Invoke(_reward);
            Deactivate();
        }
    }
}