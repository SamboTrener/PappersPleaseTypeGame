using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ShiftManager : MonoBehaviour
{
    public static ShiftManager Instance { get; private set; }

    public Employee CurrentEmployee { get; private set; }

    List<EmployeeSO> employeeSOs;

    [SerializeField] TextMeshProUGUI TextOnShiftStart;

    int monstersKilled;
    int employeeAccepted;

    private void Awake()
    {
        Instance = this;
    }

    public void StartShift(ShiftSO shift)
    {
        employeeSOs = EmployeeManager.Instance.GetDailyListOfEmployees(shift.VisitersCount);

        StartCoroutine(ShowTextForSeconds(shift.ShiftName));
        StartCoroutine(NextEmployeeAfterWait());
    }

    public IEnumerator ShowTextForSeconds(string shiftName)
    {
        ButtonOnMoving.OnButtonsDisable?.Invoke();
        TextOnShiftStart.text = shiftName;
        TextOnShiftStart.gameObject.SetActive(true);
        yield return new WaitForSeconds(GameManager.Instance.StandartTimeToWait);
        TextOnShiftStart.gameObject.SetActive(false);
        ButtonOnMoving.OnButtonsEnable?.Invoke();
    }

    public void ContinueShift(bool isPreviousAccepted)
    {
        if(isPreviousAccepted != CurrentEmployee.HasPermission())
        {
            if(isPreviousAccepted == true)
            {
                StartCoroutine(LooseGameWindow.Instance.LooseGameWithMessageAfterWait("Вы пропустили монстра и он всех убил блин"));
            }
            else
            {
                StartCoroutine(LooseGameWindow.Instance.LooseGameWithMessageAfterWait("Вы ликвидировали сотрудинка завода. Ну вы и тварь"));
            }
            return;
        }
        else
        {
            if(isPreviousAccepted == true)
            {
                employeeAccepted++;
            }
            else
            {
                monstersKilled++;
            }
        }
        if(employeeSOs.Count > 0)
        {
            StartCoroutine(NextEmployeeAfterWait());
        }
        else
        {
            StartCoroutine(ShiftEndWindow.Instance.ShowShiftEndWindowAfterWait(monstersKilled, employeeAccepted));
        }
    }

    void NextEmployee()
    {
        var next = employeeSOs.FirstOrDefault();
        employeeSOs.Remove(next);
        CurrentEmployee = EmployeeManager.Instance.SpawnEmployeeWithSO(next);
    }

    IEnumerator NextEmployeeAfterWait()
    {
        yield return new WaitForSeconds(GameManager.Instance.StandartTimeToWait);
        NextEmployee();
    }
}
