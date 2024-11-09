using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Burst.CompilerServices;
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

    public bool IsLastCharacter { get; private set; } = false;

    private void Awake()
    {
        Instance = this;
    }

    public void StartShift(ShiftSO shift)
    {
        employeeSOs = EmployeeManager.Instance.GetDailyListOfEmployees(shift.VisitersCount);

        plotCharacters = new List<PlotCharacterSO>(shift.plotCharacters);

        StartCoroutine(ShowTextForSeconds(shift.ShiftNameRu));


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
            if (isPreviousAccepted == true)
            {
                StartCoroutine(LooseGameWindow.Instance.LooseGameWithAnimation("Вы провалились, пропустив одного из [них]. Объект вышел из под контроля." +
                                                                                    " Остаётся только гадать, какие ужасные последствия это за собой повлечет"));
            }
            else
            {
                IronCurtain.Instance.OnIronCurtainDown?.Invoke();
                currentCharacter.StopPlayingSound();
                StartCoroutine(LooseGameWindow.Instance.LooseGameWithMessageAfterWait("Вы проявили излишнюю подозрительность и ликвидировали сотрудника Завода."
                          + " В конце смены вас встретила всенародная милиция. Завтра вы будете осуждены за убийство и подрывную деятельность. Слава Заводу!"));
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
                IronCurtain.Instance.OnIronCurtainDown?.Invoke();
                currentCharacter.StopPlayingSound();
                monstersKilled++;
            }
        }
        ContinueShift();
    }


    public void ContinueShift()
    {
        if (employeeSOs.Count > 0)
        {
            currentCharacterNumber++;
            if (TryGetPlotCharacter(out PlotCharacterSO plotCharacterSO))
            {
                if (plotCharacterSO == plotCharacters.Last())
                {
                    IsLastCharacter = true;
                }
                StartCoroutine(StartPlotActionAfterWait(plotCharacterSO));
            }
            else
            {
                StartCoroutine(NextEmployeeAfterWait());
            }
        }
        else
        {
            CompleteShift();
        }
    }

    void CompleteShift()
    {
        SaveLoadManager.SaveCurrentShiftToCompleted();
        currentCharacterNumber = 0;
        StartCoroutine(ShiftEndWindow.Instance.ShowShiftEndWindowAfterWait(monstersKilled, employeeAccepted));
        monstersKilled = 0;
        employeeAccepted = 0;
    }

    public void CompleteShiftTemp() => CompleteShift();

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
        currentCharacter.Move(shouldMoveRight);
    }

    void NextEmployee()
    {
        var next = employeeSOs.FirstOrDefault();
        employeeSOs.Remove(next);
        currentCharacter = CharacterSpawner.Instance.SpawnEmployeeWithSO(next, false);
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
