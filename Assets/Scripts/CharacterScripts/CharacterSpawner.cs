using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CharacterSpawner : MonoBehaviour
{
    public static CharacterSpawner Instance { get; private set; }

    [SerializeField] Transform leftSpawnPoint;
    [SerializeField] Transform rightSpawnPoint;
    [SerializeField] Transform employeePrefab;
    [SerializeField] Transform plotCharacterPrefab;

    private void Awake()
    {
        Instance = this;
    }

    public Employee SpawnEmployeeWithSO(EmployeeSO employeeSO)
    {
        var employeeTransform = Instantiate(employeePrefab, leftSpawnPoint.transform);
        var mover = employeeTransform.GetComponent<CharacterMover>();
        mover.MoveRight(false);
        var employee = employeeTransform.GetComponent<Employee>();
        employee.MapData(employeeSO);
        return employee;
    }

    public PlotCharacter SpawnPlotCharacterWithSO(PlotCharacterSO plotCharacterSO)
    {
        var spawnPoint = plotCharacterSO.isFromLeft ? leftSpawnPoint : rightSpawnPoint;

        var plotCharacterTransform = Instantiate(plotCharacterPrefab, spawnPoint.transform);
        var mover = plotCharacterTransform.GetComponent<CharacterMover>();

        if (spawnPoint == leftSpawnPoint)
        {
            mover.MoveRight(false);
            Debug.Log("Moving right");
        }
        else
        {
            mover.MoveLeft(false);
            Debug.Log("Moving left");
        }

        var character = plotCharacterTransform.GetComponent<PlotCharacter>();
        character.MapData(plotCharacterSO);
        return character;
    }
}
