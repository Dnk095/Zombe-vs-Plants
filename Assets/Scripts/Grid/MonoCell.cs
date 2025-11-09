using UnityEngine;

public class MonoCell : MonoBehaviour
{
    public MonoCell()
    {
        IsBisy = false;
    }

    public bool IsBisy { get; private set; }

    public void ChangeState()
    {
        IsBisy = !IsBisy;
    }
}
