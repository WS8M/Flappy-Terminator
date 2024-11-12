using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private ScoreCounter _scoreCounter; 
    [SerializeField] private float _maxSpawnPositionY;
    [SerializeField] private float _minSpawnPositionY;
    [SerializeField] private float _spawnDelay;
    
    private void Start()
    {
        StartCoroutine(SpawnWithDelay());
    }
    
    public void Reset()
    {
        for (int i = SpawnedObjects.Count - 1; i >= 0; i--)
        {
            var enemy = SpawnedObjects[i];
            enemy.Reset();
            enemy.Deactivate();
        }
    }
    
    protected override Enemy OnCreate()
    {
        return Instantiate(Prefab, transform.position, Quaternion.identity);
    }

    protected override void OnGet(Enemy enemy)
    {
        var spawnPosition = new Vector2(transform.position.x,  + Random.Range(_minSpawnPositionY, _maxSpawnPositionY));
        
        enemy.transform.position = spawnPosition;
        enemy.gameObject.SetActive(true);
        
        enemy.Activate();
        enemy.DestroyedByPlayer += _scoreCounter.AddScore;
    }

    protected override void OnRelease(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
        enemy.DestroyedByPlayer -= _scoreCounter.AddScore;
    }

    private IEnumerator SpawnWithDelay()
    {
        var wait = new WaitForSeconds(_spawnDelay);
        
        while (enabled)
        {
            Spawn();
            yield return wait;
        }
    }

    private void Spawn()
    {
        GetObjectFromPool();
    }
}