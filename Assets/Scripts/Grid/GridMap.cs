using UnityEngine;
using UnityEngine.UIElements;

public class GridMap : MonoBehaviour
{
    [SerializeField] private int _width;
    [SerializeField] private int _length;
    [SerializeField] private float _cellSize;

    private Cell[,] _grid;

    private void Awake()
    {
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

    public Vector3 GetRandomFreeCellPosition()
    {
        int x = GetRandomNumber(_width);
        int z = GetRandomNumber(_length);

        while (_grid[x, z].IsBisy == true)
        {
            x = GetRandomNumber(_width);
            z = GetRandomNumber(_length);
        }

        _grid[x, z].ChangeState();

        return transform.position + new Vector3(x + 0.5f, 0, z + 0.5f) * _cellSize;
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
                Debug.DrawLine(GetWorldPOsition(0, z), GetWorldPOsition(x, z), Color.green, 1000f);
                Debug.DrawLine(GetWorldPOsition(x, 0), GetWorldPOsition(x, z), Color.green, 1000f);
                Debug.Log(x + " " + z);
            }
    }

    private Vector3 GetWorldPOsition(int x, int z)
    {
        return new Vector3(x, 0, z) * _cellSize + transform.position;
    }

    private void Fill()
    {
        for (int i = 0; i < _width; i++)
            for (int j = 0; j < _length; j++)
            {
                _grid[i, j] = new Cell();
            }
    }
}