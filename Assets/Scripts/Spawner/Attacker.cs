using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private BulletSpawner _bulletSpawner;
    
    private void Start() => 
        _bulletSpawner.Initialize(_spawnPoint, _bulletSpeed);

    public void Attack() => 
        _bulletSpawner.GetBullet();

    public void Reset() => 
        _bulletSpawner.Reset();
}