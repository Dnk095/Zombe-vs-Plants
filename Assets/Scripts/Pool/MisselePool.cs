using UnityEngine;
using UnityEngine.Pool;

public class MisselePool : MonoBehaviour
{
    [SerializeField] private Missele _prefab;

    private ObjectPool<Missele> _pool;


    private void Awake()
    {
        _pool = new ObjectPool<Missele>
           (
                       createFunc: () => CreateObject(),
           actionOnGet: (obj) => Spawn(obj),
           actionOnRelease: (obj) => Release(obj)
           );
    }

    public Missele GetObject()
    {
        return _pool.Get();
    }

    private void Release(Missele missele)
    {
        missele.gameObject.SetActive(false);
        missele.Releasing -= OnRelease;
    }

    private void OnRelease(Missele missele)
    {
        _pool.Release(missele);
    }

    private void Spawn(Missele missele)
    {
        missele.gameObject.SetActive(true);
        missele.Releasing += OnRelease;
    }

    private Missele CreateObject()
    {
        Missele missele = Instantiate(_prefab);
        missele.transform.parent = transform;
        return missele;
    }
}
