using UnityEngine;

public class GridMap : MonoBehaviour
{
    [SerializeField] private int _width;
    [SerializeField] private int _length;
    [SerializeField] private MonoCell _cell;

    private float _cellSize;
    private MonoCell[,] _grid;

    private void Awake()
    {
        _grid = new MonoCell[_width, _length];
        _cellSize = _cell.transform.localScale.x;
        Fill();
    }

    private void Fill()
    {
        MonoCell cell;
        Vector3 newPOsition;

        for (int i = 0; i < _width; i++)
            for (int j = 0; j < _length; j++)
            {
                newPOsition = new Vector3(transform.position.x + i * 2*_cellSize, 0, transform.position.z + j * 2* _cellSize);
                cell = Instantiate(_cell);
                cell.transform.position = newPOsition;
                cell.transform.parent = transform;
                _grid[i, j] = cell;
            }
    }
}