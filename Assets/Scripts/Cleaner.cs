using UnityEngine;

[RequireComponent (typeof(BoxCollider))]
public class Cleaner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("1");
        if (other.TryGetComponent(out Missele missele))
        {
            Debug.Log("2");
            missele.Release();
        }
    }
}
