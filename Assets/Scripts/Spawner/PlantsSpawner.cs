using System.Collections.Generic;
using UnityEngine;

public class PlantsSpawner : MonoBehaviour
{
    [SerializeField] private List<UnitButton> _spawnButtons;
    [SerializeField] private PlantingHandler _planting;

    private Plant _currentPLant;

    private void OnEnable()
    {
        foreach (UnitButton button in _spawnButtons)
            button.Clicked += OnSpawnButtonClick;
    }

    private void OnDisable()
    {
        foreach (UnitButton button in _spawnButtons)
            button.Clicked -= OnSpawnButtonClick;
    }

    private void OnSpawnButtonClick(Plant plant)
    {
        _planting.GetNearestCenterPOsition();
    }
}