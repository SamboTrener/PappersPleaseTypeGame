using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeManager : MonoBehaviour
{
    public static EmployeeManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] List<EmployeeSO> employeeSOs;
    [SerializeField] Transform employeeSpawnPoint;
    [SerializeField] Transform employeePrefab;

    public List<EmployeeSO> GetAvailableEmployeesList() => employeeSOs;

    public List<EmployeeSO> GetDailyListOfEmployees(int count)
    {
        var result = new List<EmployeeSO>();

        for (int i = 0; i < count; i++)
        {
            result.Add(employeeSOs[i]);
        }
        return result;
    }

    void BreakEmployee(EmployeeSO employee)
    {

    }

    public Employee SpawnEmployeeWithSO(EmployeeSO employeeSO)
    {
        var employeeTransform = Instantiate(employeePrefab, employeeSpawnPoint.transform);
        var mover = employeeTransform.GetComponent<EmployeeMover>();
        mover.MoveRight(false);
        var employee = employeeTransform.GetComponent<Employee>();
        employee.MapSprite(employeeSO);
        return employee;
    }
}
