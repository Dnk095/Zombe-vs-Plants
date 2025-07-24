using UnityEngine;
using UnityEngine.Pool;

public class Pool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;

    private ObjectPool<T> _pool;


    private void Awake()
    {
        _pool = new ObjectPool<T>
           (
           createFunc: () => CreateObject(),
           actionOnGet: (obj) => Spawn(obj),
           actionOnRelease: (obj) => Release(obj)
           );
    }

    public T GetObject()
    {
        return _pool.Get();
    }

    protected virtual void OnReleasing(T spawnedObject)
    {
        _pool.Release(spawnedObject);
    }

    protected virtual void Spawn(T spawnedObject)
    {
        spawnedObject.gameObject.SetActive(true);
    }

    private void Release(T spawnObject)
    {
        spawnObject.gameObject.SetActive(false);
    }

    private T CreateObject()
    {
        T spawnedObject = Instantiate(_prefab);
        spawnedObject.transform.parent = transform;
        return spawnedObject;
    }
}