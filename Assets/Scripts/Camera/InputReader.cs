using System;
using Unity.VisualScripting;
using UnityEngine;

internal class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    private const string Zoom = "Mouse ScrollWheel";

   // private int _mouseButtonSelect = 0;
   // private int _mouseButtonDeselect = 1;

    public float VerticalDirection { get; private set; }
    public float HorizontalDirection { get; private set; }
    public float VerticalZoom { get; private set; }

    //public event Action Selecting;
    // public event Action Deselecting;

    private void Update()
    {
        HorizontalDirection = Input.GetAxis(Horizontal);
        VerticalDirection = Input.GetAxis(Vertical);
        VerticalZoom = Input.GetAxis(Zoom);

        //if (Input.GetMouseButtonDown(_mouseButtonSelect))
        // Selecting?.Invoke();
        // else if (Input.GetMouseButtonDown(_mouseButtonDeselect))
        // Deselecting?.Invoke();
    }
}