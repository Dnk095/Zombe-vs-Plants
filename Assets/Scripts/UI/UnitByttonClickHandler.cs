using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitByttonClickHandler : MonoBehaviour
{
    [SerializeField] private List<UnitButton> _spawnButtons;
    [SerializeField] private PeaPool _peaPool;
    [SerializeField] private SunFlowerPool _sunFlowerPool;
    [SerializeField] private PeaWeapons _peaSimulate;
    [SerializeField] private SunFlower _sunFlowerSimulate;

    public event Action<Plant> UnitButtonClicked;

    private void Awake()
    {
        _peaSimulate.gameObject.SetActive(false);
        _sunFlowerSimulate.gameObject.SetActive(false);
    }

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
        UnitButtonClicked?.Invoke(plant);
    }
}
