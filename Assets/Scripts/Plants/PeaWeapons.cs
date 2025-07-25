using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaWeapons : Plant
{
    [SerializeField] private MisselePool _pool;
    [SerializeField] private float _attackTime;
    [SerializeField] private Transform _misseleSTartPosition;

    private Coroutine _coroutine;

    private void Start()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        //_coroutine = StartCoroutine(Shoting());
    }

    private void Shoot()
    {
        Missele missele = _pool.GetObject();
        missele.Init(_misseleSTartPosition);
        missele.Move();
    }

    private IEnumerator Shoting()
    {
        WaitForSeconds wait = new WaitForSeconds(_attackTime);

        while (enabled)
        {
            Shoot();
            yield return wait;
        }
    }
}
