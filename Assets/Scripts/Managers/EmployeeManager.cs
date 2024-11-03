using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EmployeeManager : MonoBehaviour
{
    public static EmployeeManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] List<EmployeeSO> employeeSOs;
    [SerializeField] int minAllowedEmployeeCount;
    [SerializeField] int minNotAllowedEmployeeCount;

    public List<EmployeeSO> GetAvailableEmployeesList() => employeeSOs;

    public List<EmployeeSO> GetDailyListOfEmployees(int count)
    {
        var employeeSOsCopy = new List<EmployeeSO>(employeeSOs);
        var result = new List<EmployeeSO>();

        for(int i = 0; i < minAllowedEmployeeCount; i++) //Allowed employeee only
        {
            result.Add(GetEmployeeSO(employeeSOsCopy, false));
        }
        for(int i = 0; i < minNotAllowedEmployeeCount; i++) //Not allowed employee only
        {
            result.Add(GetEmployeeSO(employeeSOsCopy, true));
        }

        for (int i = 0; i < count - minAllowedEmployeeCount - minNotAllowedEmployeeCount; i++) //Randomly allowed or not allowed
        {
            if(Random.value > 0.5f)
            {
                result.Add(GetEmployeeSO(employeeSOsCopy, true));
            }
            else
            {
                result.Add(GetEmployeeSO(employeeSOsCopy, false));
            }
        }

        var random = new System.Random();
        return result.OrderBy(x => random.Next()).ToList();
    }

    EmployeeSO GetEmployeeSO(List<EmployeeSO> employeeSOsCopy, bool shouldBreak)
    {
        var nextEmployee = employeeSOsCopy[Random.Range(0, employeeSOsCopy.Count)];
        var nextEmployeeCopy = EmployeeSO.CreateInstance(nextEmployee);

        nextEmployeeCopy.greeting = DialogueManager.Instance.GetRandomValidGreeting();
        if (shouldBreak)
        {
            BreakEmployee(nextEmployeeCopy);
        }

        employeeSOsCopy.Remove(nextEmployee);
        return nextEmployeeCopy;
    }

    void BreakEmployee(EmployeeSO employee)
    {
        switch (GameManager.Instance.DifficultyLevel)
        {
            case DifficultyLevel.Easy:
                BreakSprite(employee);
                break;
            case DifficultyLevel.Medium:
                if(Random.value > 0.5f)
                {
                    BreakSprite(employee);
                }
                else
                {
                    BreakGreeting(employee);
                }
                break;
            case DifficultyLevel.Hard:
                var randomValue = Random.value;
                if(randomValue <= 0.33)
                {
                    BreakSprite(employee);
                }
                else if(randomValue <= 0.66)
                {
                    BreakGreeting(employee);
                }
                else
                {
                    BreakDocuments(employee);
                }
                break;
        }
        employee.hasPermission = false;
    }

    void BreakSprite(EmployeeSO employee)
    {
        employee.baseSprite = employee.spritesWithAnomaly[Random.Range(0, employee.spritesWithAnomaly.Length)]; 
    }

    void BreakGreeting(EmployeeSO employee)
    {
        employee.greeting = DialogueManager.Instance.GetRandomInvalidGreeting();
    }

    void BreakDocuments(EmployeeSO employee)
    {
        var randomValue = Random.value;
        if (randomValue <= 0.33)
        {
            employee.employeeName = employee.anomalyNameList[Random.Range(0, employee.anomalyNameList.Count)];
            employee.employeeNameRu = employee.anomalyNameListRu[Random.Range(0, employee.anomalyNameListRu.Count)];
        }
        else if (randomValue <= 0.66)
        {
            employee.age += Random.Range(-20, 20);
        }
        else
        {
            employee.passID = Random.Range(100000, 999999).ToString();
        }
    }

    public List<EmployeeSO> GetAllEmployeeSOsWithBrokenSprite()
    {
        var result = new List<EmployeeSO>();
        foreach(var employeeSO in employeeSOs)
        {
            for(int i = 0; i < employeeSO.spritesWithAnomaly.Length; i++)
            {
                var employeeSOCopy = EmployeeSO.CreateInstance(employeeSO);
                employeeSOCopy.baseSprite = employeeSOCopy.spritesWithAnomaly[i];
                result.Add(employeeSOCopy);
            }
        }
        var random = new System.Random();
        return result.OrderBy(x => random.Next()).ToList();
    }
}
