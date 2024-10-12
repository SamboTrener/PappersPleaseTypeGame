using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShiftManager : MonoBehaviour
{
    public static ShiftManager Instance { get; private set; }

    public Employee CurrentEmployee { get; private set; }

    List<EmployeeSO> employeeSOs;

    private void Awake()
    {
        Instance = this;
    }

    public void StartShift(ShiftSO shift)
    {
        employeeSOs = EmployeeManager.Instance.GetDailyListOfEmployees(shift.VisitersCount);
        NextEmployee();
    }

    public void NextEmployee()
    {
        var next = employeeSOs.FirstOrDefault();
        employeeSOs.Remove(next);
        CurrentEmployee = EmployeeManager.Instance.SpawnEmployeeWithSO(next);
    }

    public IEnumerator NextEmployeeAfterWait()
    {
        yield return new WaitForSeconds(3f);
        NextEmployee();
    }
}
