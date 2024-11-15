using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour, IPoolable
{
    [SerializeField] protected T Prefab;
    [SerializeField] private int _poolCapacity;
    [SerializeField] private int _poolMaxSize;

    private ObjectPool<IPoolable> _pool;
    
    protected List<T> SpawnedObjects;
    
    private void Awake()
    {
        _pool = new ObjectPool<IPoolable>(
            createFunc: Create,
            actionOnGet: Get,
            actionOnRelease: Release,
            actionOnDestroy: Destroy,
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
        
        SpawnedObjects = new List<T>(); 
    }
    
    protected abstract T OnCreate();
    
    protected abstract void OnGet(T enemy);
    
    protected abstract void OnRelease(T obj);
    
    protected void GetObjectFromPool()
    {
        IPoolable obj = _pool.Get();
        obj.Removed += RemoveObject;
        
        SpawnedObjects.Add(obj as T);
    }

    private void RemoveObject(IPoolable obj)
    {
        _pool.Release(obj as T);
        obj.Removed -= RemoveObject;
        
        SpawnedObjects.Remove(obj as T);
    }
    
    private T Create() => 
        OnCreate();

    private void Get(IPoolable obj) => 
        OnGet(obj as T);

    private void Release(IPoolable obj) => 
        OnRelease(obj as T);

    private void Destroy(IPoolable obj) => 
        Destroy((obj as T).gameObject);
}