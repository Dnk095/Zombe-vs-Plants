using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GridMap : MonoBehaviour
{
    [SerializeField] private int _width;
    [SerializeField] private int _length;
    [SerializeField] private float _cellSize;

    private Cell[,] _grid;
    private List<Vector3> _centers;

    private void Awake()
    {
        _centers = new List<Vector3>();
        _grid = new Cell[_width, _length];
        Fill();
    }

    private void Start()
    {
        DrawGrid();
    }

    public void RefreshCell()
    {
        for (int x = 0; x < _grid.GetLength(0); x++)
        {
            for (int y = 0; y < _grid.GetLength(1); y++)
                if (_grid[x, y].IsBisy == true)
                    _grid[x, y].ChangeState();
        }
    }

    public List<Vector3> GetCenters()
    {
        return new List<Vector3>(_centers);
    }

    private int GetRandomNumber(int x)
    {
        return Random.Range(0, x);
    }

    private void DrawGrid()
    {
        for (int x = 0; x < _grid.GetLength(0) + 1; x++)
            for (int z = 0; z < _grid.GetLength(1) + 1; z++)
            {
                Debug.DrawLine(GetWorldPOsition(0, z), GetWorldPOsition(x, z), Color.red, 100f);
                Debug.DrawLine(GetWorldPOsition(x, 0), GetWorldPOsition(x, z), Color.red, 100f);
            }
    }

    private Vector3 GetWorldPOsition(int x, int z)
    {
        return new Vector3(x, 0, z) * _cellSize + transform.position;
    }

    private void Fill()
    {
        Vector3 center;

        for (int i = 0; i < _width; i++)
            for (int j = 0; j < _length; j++)
            {
                _grid[i, j] = new Cell();
                center = new Vector3(transform.position.x + (i + 0.5f) * _cellSize, transform.position.y, transform.position.z + (j + 0.5f) * _cellSize);
                _centers.Add(center);
            }
    }
}