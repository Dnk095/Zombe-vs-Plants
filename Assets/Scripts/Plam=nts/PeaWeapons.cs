using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaWeapons : MonoBehaviour
{
    [SerializeField] private Missele _missele;
    [SerializeField] private float _attackTime;
    [SerializeField] private Transform _misseleSTartPosition;

    private Coroutine _coroutine;

    private void Start()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Shoting());
    }

    private void Shoot()
    {
        Missele missele = Instantiate(_missele);
        missele.transform.position = _misseleSTartPosition.position;
        _missele.transform.Translate(0, 0, 10);
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
