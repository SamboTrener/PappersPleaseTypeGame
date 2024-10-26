using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmployeesListMenu : MonoBehaviour
{
    [SerializeField] Button employeeListButton;
    [SerializeField] Transform cellPrefab;
    [SerializeField] Transform cellSpawnPoint;

    private void Awake()
    {
        employeeListButton.onClick.AddListener(OpenMenu);
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
        SoundManager.Instance.PlayPaperSound(employeeListButton.gameObject.transform.position);
        gameObject.SetActive(true);
    }

    void CloseMenu()
    {
        gameObject.SetActive(false);
    }
}
