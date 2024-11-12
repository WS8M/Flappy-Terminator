using UnityEngine;

public class BulletSpawner : Spawner<Bullet>
{
    private float _bulletSpeed;
    private Transform _spawnPoint;

    public void Initialize(Transform spawnPoint, float bulletSpeed)
    {
        _spawnPoint = spawnPoint;
        _bulletSpeed = bulletSpeed;
    }
    
    public void GetBullet() => 
        GetObjectFromPool();

    public void Reset()
    {
        for (int i = SpawnedObjects.Count - 1; i >= 0; i--) 
            SpawnedObjects[i].Deactivate();
    }
    
    protected override Bullet OnCreate() => 
        Instantiate(Prefab, _spawnPoint.position, _spawnPoint.rotation);

    protected override void OnGet(Bullet bullet) => 
        bullet.Activate(_spawnPoint.position,_spawnPoint.rotation, _bulletSpeed);

    protected override void OnRelease(Bullet bullet) => 
        bullet.gameObject.SetActive(false);
}
