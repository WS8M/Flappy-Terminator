using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, IInteractable, IPoolable
{
    [SerializeField] private Attacker _attacker;
    [SerializeField] private CollisionHandler _collisionHandler;
    [SerializeField] private float _attackDelay;
    [SerializeField] private float _reward = 1f;

    private Coroutine _currentCoroutine;
    
    public event Action<IPoolable> Removed;
    public event Action<float> DestroyedByPlayer;

    private void OnEnable() => 
        _collisionHandler.CollisionDetected += OnCollisionWithInteract;

    private void OnDisable() => 
        _collisionHandler.CollisionDetected -= OnCollisionWithInteract;

    public void Activate()
    {
        if (_currentCoroutine == null)
        {
            _currentCoroutine = StartCoroutine(Attack());
            return;            
        }
        
        StopCoroutine(_currentCoroutine);
        _currentCoroutine = StartCoroutine(Attack());
    }
    
    public void Deactivate()
    {
        StopCoroutine(_currentCoroutine);
        Removed?.Invoke(this);
    }
    
    public void Reset() => 
        _attacker.Reset();
    
    private IEnumerator Attack()
    {
        var wait = new WaitForEndOfFrame();
        float currentTime = _attackDelay;
        
        while (enabled)
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
            }
            else
            {
                _attacker.Attack();
                currentTime = _attackDelay;
            }
            
            yield return wait;
        }
    }

    private void OnCollisionWithInteract(IInteractable interactable)
    {
        if (interactable as Bullet)
        {
            DestroyedByPlayer?.Invoke(_reward);
            Deactivate();
        }
    }
}