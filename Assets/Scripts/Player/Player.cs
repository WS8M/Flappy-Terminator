using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private CollisionHandler _collisionHandler;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private Attacker _attacker;
    
    [SerializeField] private float _shootDelay;
    private float _currentDelay;
    
    public event Action GameOver;

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += OnCollisionWithInteractable;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= OnCollisionWithInteractable;
    }

    private void Update()
    {
        _currentDelay -= Time.deltaTime;
        
        if (_playerInput.AttackInput && _currentDelay < 0)
        {
            _attacker.Attack();
            _currentDelay = _shootDelay;
        }
        
        if(_playerInput.JumpInput)
            _playerMover.Jump();
    }
    
    public void Reset()
    {
        _currentDelay = 0;
        _scoreCounter.Reset();
        _playerMover.Reset();
    }

    private void OnCollisionWithInteractable(IInteractable interactable)
    {
        if (interactable as Bullet || interactable as Enemy || interactable as Ground)
        {
            GameOver?.Invoke();
        }
    }
}