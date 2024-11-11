using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private CollisionHandler _collisionHandler;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private Attacker _attacker;
    
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            _attacker.Attack();
        }
    }
    
    public void Reset()
    {
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