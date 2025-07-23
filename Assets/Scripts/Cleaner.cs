using UnityEngine;

[RequireComponent (typeof(BoxCollider))]
public class Cleaner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Missele missele))
            missele.Release();
    }
}
