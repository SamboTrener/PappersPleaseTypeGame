using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Employee : MonoBehaviour
{
    Image employeeImage;
    EmployeeSO employeeSO;

    private void Awake()
    {
        employeeImage = GetComponent<Image>();
    }

    public void MapSprite(EmployeeSO employeeSO)
    {
        this.employeeSO = employeeSO;
        employeeImage.sprite = employeeSO.baseSprite;
    }

    public bool HasPermission() => employeeSO.hasPermission;
}
