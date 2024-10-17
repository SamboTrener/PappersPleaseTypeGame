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
    [SerializeField] int minAllowedEmployeeCount;
    [SerializeField] int minNotAllowedEmployeeCount;

    public List<EmployeeSO> GetAvailableEmployeesList() => employeeSOs;

    public List<EmployeeSO> GetDailyListOfEmployees(int count)
    {
        var employeeSOsCopy = new List<EmployeeSO>(employeeSOs);
        var result = new List<EmployeeSO>();

        for(int i = 0; i < minAllowedEmployeeCount; i++) //Наши слоны
        {
            var nextEmployee = employeeSOsCopy[Random.Range(0, employeeSOsCopy.Count - 1)];
            nextEmployee.greeting = DialogueManager.Instance.GetRandomValidGreeting();
            nextEmployee.greeting = DialogueManager.Instance.GetRandomValidGreeting();
            result.Add(nextEmployee);
            employeeSOsCopy.Remove(nextEmployee);
        }

        for(int i = 0; i < minNotAllowedEmployeeCount; i++) //Не наши слоны 
        {
            var nextEmployee = employeeSOsCopy[Random.Range(0, employeeSOsCopy.Count - 1)];

            var nextEmployeeCopy = EmployeeSO.CreateInstance(nextEmployee);

            nextEmployeeCopy.greeting = DialogueManager.Instance.GetRandomValidGreeting();
            
            BreakEmployee(nextEmployeeCopy);

            result.Add(nextEmployeeCopy);
            employeeSOsCopy.Remove(nextEmployee);
        }

        for (int i = 0; i < count - minAllowedEmployeeCount - minNotAllowedEmployeeCount; i++) //А вот тут поди пойми 
        {
            var nextEmployee = employeeSOsCopy[Random.Range(0, employeeSOsCopy.Count - 1)];

            var nextEmployeeCopy = EmployeeSO.CreateInstance(nextEmployee);

            nextEmployeeCopy.greeting = DialogueManager.Instance.GetRandomValidGreeting();
            if (Random.value > 0.5f)
            {
                BreakEmployee(nextEmployeeCopy);
            }

            result.Add(nextEmployeeCopy);
            employeeSOsCopy.Remove(nextEmployee);
        }
        return result;
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
        employee.baseSprite = employee.spritesWithAnomaly[Random.Range(0, employee.spritesWithAnomaly.Length - 1)]; 
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
            employee.employeeName = employee.anomalyNameList[Random.Range(0, employee.anomalyNameList.Count - 1)];
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
}
