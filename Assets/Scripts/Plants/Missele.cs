using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Missele : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Coroutine _coroutine;

    public void Move()
    {
        _coroutine = StartCoroutine(Flying());
    }

    public void Init(Transform currentPosition)
    {
        transform.rotation = currentPosition.rotation;
        transform.position = currentPosition.position;
    }

    public void Return()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator Flying()
    {
        WaitForSeconds wait = new WaitForSeconds(Time.fixedDeltaTime);

        while (enabled)
        {
            transform.Translate(Vector3.right * _speed, Space.Self);
            yield return wait;
        }
    }
}