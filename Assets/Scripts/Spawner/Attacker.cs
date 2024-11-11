using UnityEngine;

public class Attacker : Spawner<Bullet>
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _bulletSpeed;
    
    public void Attack() => 
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
