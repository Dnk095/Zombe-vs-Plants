using System;
using System.Collections.Generic;
using UnityEngine;

public class PlantingSimulator : MonoBehaviour
{
    [SerializeField] private UnitByttonClickHandler _unitHandler;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GridMap _gridMap;
    [SerializeField] private Camera _camera;
    [SerializeField] private PeaWeapons _weapon;

    private MonoCell _currentCell;
    private Ray _ray;
    private RaycastHit _hit;
    private bool _startSimulating = false;

    public event Action<Vector3> PLanting;

    private void FixedUpdate()
    {
        if (_startSimulating)
            if (TryGetCellPosition(out Vector3 position))
                PLanting?.Invoke(position);
    }

    private void OnEnable()
    {
        _unitHandler.UnitButtonClicked += OnSpawnButtonClick;
        _inputReader.Deselecting += StopSimulations;
        _inputReader.Selecting += OnSelectButtonClick;
    }

    private void OnDisable()
    {
        _unitHandler.UnitButtonClicked -= OnSpawnButtonClick;
        _inputReader.Deselecting -= StopSimulations;
        _inputReader.Selecting -= OnSelectButtonClick;
    }

    private bool TryGetCellPosition(out Vector3 position)
    {
        _startSimulating = true;

        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        position = Vector3.zero;

        if (Physics.Raycast(_ray, out _hit, Mathf.Infinity) && _hit.collider.TryGetComponent(out MonoCell cell) && cell.IsBisy == false)
        {
            _weapon.gameObject.SetActive(true);

            if (cell != _currentCell)
            {
                _currentCell = cell;

                position = new(_currentCell.transform.position.x, 0, _currentCell.transform.position.z);
                _weapon.transform.position = position;
            }

            return true;
        }
        else
        {
            _weapon.gameObject.SetActive(false);

            return false;
        }
    }

    public void SimulatePlanting()
    {
        _startSimulating = true;
    }

    private void StopSimulations()
    {
        _weapon.gameObject.SetActive(false);
        _startSimulating = false;
    }

    private void OnSpawnButtonClick(Plant plant)
    {
        SimulatePlanting();
    }

    private void OnSelectButtonClick()
    {
        if (_startSimulating == true && _weapon.enabled == true)
        {
            PLanting?.Invoke(Vector3.zero);
        }
    }
}
