using UnityEngine;

public class Cell
{
    public Cell()
    {
        IsBisy = false;
    }

    public bool IsBisy { get; private set; }

    public void ChangeState()
    {
        IsBisy = !IsBisy;
    }
}
