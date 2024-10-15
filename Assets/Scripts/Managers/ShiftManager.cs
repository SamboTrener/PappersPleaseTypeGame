using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ShiftManager : MonoBehaviour
{
    public static ShiftManager Instance { get; private set; }

    [SerializeField] TextMeshProUGUI textOnShiftStart;
   
    List<PlotCharacterSO> plotCharacters;
    int monstersKilled;
    int employeeAccepted;
    List<EmployeeSO> employeeSOs;
    CommonCharacter currentCharacter;
    int currentCharacterNumber = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void StartShift(ShiftSO shift)
    {
        employeeSOs = EmployeeManager.Instance.GetDailyListOfEmployees(shift.VisitersCount);

        plotCharacters = new List<PlotCharacterSO>(shift.plotCharacters);

        StartCoroutine(ShowTextForSeconds(shift.ShiftName));


        if (TryGetPlotCharacter(out PlotCharacterSO plotCharacterSO))
        {
            StartCoroutine(StartPlotActionAfterWait(plotCharacterSO));
        }
        else
        {
            StartCoroutine(NextEmployeeAfterWait());
        }
    }

    public void ContinueShiftWithPlayerActions(bool isPreviousAccepted)
    {
        MoveCurrentCharacter(isPreviousAccepted);
        if (isPreviousAccepted != currentCharacter.HasPermission())
        {
            if (isPreviousAccepted == true) //Теперь сотрудник не проходит когда ты не прав
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
            if (isPreviousAccepted == true)
            {
                employeeAccepted++;
            }
            else
            {
                monstersKilled++;
            }
        }
        ContinueShift();
    }


    public void ContinueShift()
    {
       // MoveCurrentCharacter(shouldMoveRight);
        if (employeeSOs.Count > 0)
        {
            currentCharacterNumber++;
            if (TryGetPlotCharacter(out PlotCharacterSO plotCharacterSO))
            {
                StartCoroutine(StartPlotActionAfterWait(plotCharacterSO));
            }
            else
            {
                StartCoroutine(NextEmployeeAfterWait());
            }
        }
        else
        {
            currentCharacterNumber = 0;
            StartCoroutine(ShiftEndWindow.Instance.ShowShiftEndWindowAfterWait(monstersKilled, employeeAccepted));
        }
    }

    bool TryGetPlotCharacter(out PlotCharacterSO outPlotCharacter)
    {
        foreach (var plotCharacter in plotCharacters)
        {
            if (plotCharacter.orderOfComming == currentCharacterNumber)
            {
                outPlotCharacter = plotCharacter;
                return true;
            }
        }
        outPlotCharacter = null;
        return false;
    }

    IEnumerator StartPlotActionAfterWait(PlotCharacterSO plotCharacterSO)
    {
        yield return new WaitForSeconds(GameManager.Instance.StandartTimeToWait);
        currentCharacter = CharacterSpawner.Instance.SpawnPlotCharacterWithSO(plotCharacterSO);
    }

    public void MoveCurrentCharacter(bool shouldMoveRight)
    {
        if (shouldMoveRight)
        {
            currentCharacter.GetComponent<CharacterMover>().MoveRight(true);
        }
        else
        {
            currentCharacter.GetComponent<CharacterMover>().MoveLeft(true);
        }
    }

    void NextEmployee()
    {
        var next = employeeSOs.FirstOrDefault();
        employeeSOs.Remove(next);
        currentCharacter = CharacterSpawner.Instance.SpawnEmployeeWithSO(next);
    }

    IEnumerator NextEmployeeAfterWait()
    {
        yield return new WaitForSeconds(GameManager.Instance.StandartTimeToWait); 
        NextEmployee();
    }

    IEnumerator ShowTextForSeconds(string shiftName)
    {
        ButtonInteractableController.OnButtonsDisable?.Invoke();
        textOnShiftStart.text = shiftName;
        textOnShiftStart.gameObject.SetActive(true);
        yield return new WaitForSeconds(GameManager.Instance.StandartTimeToWait);
        textOnShiftStart.gameObject.SetActive(false);
        ButtonInteractableController.OnButtonsEnable?.Invoke();
    }
}
