using System.Collections.Generic;
using UnityEngine;

public class PlantsSpawner : MonoBehaviour
{
    [SerializeField] private PlantingSimulator _simulator;

    private Plant _currentPLant;

    private void OnEnable()
    {
        _simulator.PLanting += Spawn;
    }

    private void OnDisable()
    {
        _simulator.PLanting -= Spawn;
    }

    private void Spawn(Vector3 position)
    {

    }
}