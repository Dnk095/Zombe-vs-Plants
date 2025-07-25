using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantingHandler : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;
    [SerializeField] private GridMap _gridMap;
    [SerializeField] private Camera _camera;
    [SerializeField] private PeaWeapons _weapon;

    private List<Vector3> _gridCenters;
    private Vector3 _nearestCenter;
    private Ray _ray;
    private RaycastHit _hit;

    public event Action<Vector3> FindingNearestCenter;

    private void Start()
    {
        _gridCenters = _gridMap.GetCenters();
    }

    public void GetNearestCenterPOsition(Plant plant)
    {
        float minDistance = float.MaxValue;
        float currentDiatnce;

        foreach (Vector3 center in _gridCenters)
        {
            currentDiatnce = CalculateMagnitude(center, GetMousePOsition());

            if (currentDiatnce < minDistance)
            {
                _nearestCenter = center;
                minDistance = currentDiatnce;
            }
        }

        StartCoroutine(Drawing(plant));
    }

    private Vector3 GetMousePOsition()
    {
        Vector3 position;

        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit, Mathf.Infinity))
        {
            position = new(_hit.point.x, 0, _hit.point.z);

            if (_hit.point.x < 0)
                position.x = 0;
            else if (_hit.point.x > 20)
                position.x = 20;

            if (_hit.point.z < 0)
                position.z = 0;
            else if (_hit.point.z > 20)
                position.z = 20;

            return position;
        }

        return Vector3.zero;
    }

    private float CalculateMagnitude(Vector3 center, Vector3 position)
    {
        return (position - center).magnitude;
    }

    private IEnumerator Drawing(Plant plant)
    {
        WaitForSeconds wait = new(Time.fixedDeltaTime);
        Plant plant1 = Instantiate(plant);

        while (enabled)
        {
            plant1.transform.position = GetMousePOsition();
            yield return wait;
        }
    }
}
