using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Employee : MonoBehaviour
{
    [SerializeField] GameObject dialogeWindow;
    [SerializeField] TextMeshProUGUI greetingText;

    Image employeeImage;
    EmployeeSO employeeSO;

    private void Awake()
    {
        employeeImage = GetComponent<Image>();
    }

    private void Start()
    {
        dialogeWindow.SetActive(false);
    }

    private void OnEnable()
    {
        EmployeeMover.OnEmployeeStopped += Greet;
        EmployeeMover.OnEmployeeStartMove += Leave;
    }

    private void OnDisable()
    {
        EmployeeMover.OnEmployeeStopped -= Greet;
        EmployeeMover.OnEmployeeStartMove -= Leave;
    }

    public void MapSprite(EmployeeSO employeeSO)
    {
        this.employeeSO = employeeSO;
        employeeImage.sprite = employeeSO.baseSprite;
    }

    void Greet()
    {
        greetingText.text = employeeSO.greeting;
        dialogeWindow.SetActive(true);
        DocumentMenu.Instance.ShowDocument(employeeSO);
        FullDescrMenu.Instance.FillDescrMenu(employeeSO);
    }

    void Leave()
    {
        dialogeWindow.SetActive(false);
    }

    public bool HasPermission() => employeeSO.hasPermission;
}
