using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmployeesListMenu : MonoBehaviour
{
    [SerializeField] Button passButton;
    [SerializeField] Button closeButton;
    [SerializeField] Transform cellPrefab;
    [SerializeField] Transform cellSpawnPoint;

    private void Awake()
    {
        passButton.onClick.AddListener(OpenMenu);
        closeButton.onClick.AddListener(CloseMenu);
    }

    private void Start()
    {
        var employeeSOs = EmployeeManager.Instance.GetAvailableEmployeesList();

        foreach (var employeeSO in employeeSOs)
        {
            var cell = Instantiate(cellPrefab, cellSpawnPoint);
            cell.GetComponent<CellOfEmployeesList>().MapCellInfoWithSO(employeeSO);
        }

        CloseMenu();
    }
    void OpenMenu()
    {
        gameObject.SetActive(true);
    }

    void CloseMenu()
    {
        gameObject.SetActive(false);
    }
}
